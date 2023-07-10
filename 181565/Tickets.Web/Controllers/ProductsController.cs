using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tickets.Domain.DomainModels;
using Tickets.Domain.DTO;
using Tickets.Services.Interface;

namespace Tickets.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productServicet)
        {
            _productService = productServicet;
        }

        // GET: Products
        public IActionResult Index()
        {
            var allProducts = this._productService.GetAllProducts();
            return View(allProducts);
        }

        public IActionResult AddProductToCard(Guid? id)
        {
            var model = this._productService.GetShoppingCartInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProductToCard([Bind("ProductId", "Quantity")] AddToShoppingCardDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._productService.AddToShoppingCart(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "Products");
            }

            return View(item);
        }

    
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this._productService.GetDetailsForProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProductName,ProductImage,ProductDescription,ProductPrice,Date,Genre")] Product product)
        {
            if (ModelState.IsValid)
            {
                this._productService.CreateNewProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

       
        public IActionResult Edit(Guid? p)
        {
            if (p == null)
            {
                return NotFound();
            }

            var product = this._productService.GetDetailsForProduct(p);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,ProductName,ProductImage,ProductDescription,ProductPrice,Date,Genre")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._productService.UpdateExistingProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this._productService.GetDetailsForProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return this._productService.GetDetailsForProduct(id) != null;
        }
    }
}
