using System;
using System.Collections.Generic;
using System.Text;
using Tickets.Domain.DomainModels;

namespace Tickets.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<ProductInShoppingCart> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
