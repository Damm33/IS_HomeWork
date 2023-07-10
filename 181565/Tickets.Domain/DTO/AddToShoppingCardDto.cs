using System;
using System.Collections.Generic;
using System.Text;
using Tickets.Domain.DomainModels;

namespace Tickets.Domain.DTO
{
    public class AddToShoppingCardDto
    {
        public Product SelectedProduct { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
