using System;
using System.Collections.Generic;
using System.Text;
using Tickets.Domain.DomainModels;
using Tickets.Domain.DTO;

namespace Tickets.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Product p);
        void UpdateExistingProduct(Product p);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
    }
}
