﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Domain.DomainModels
{
    public class Product : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Genre { get; set; }

        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public IEnumerable<ProductInOrder> ProductInOrders { get; set; }
        
    }
}
