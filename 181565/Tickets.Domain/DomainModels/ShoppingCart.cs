using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Domain.Identity;

namespace Tickets.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        
        public TicketsApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
    }
}
