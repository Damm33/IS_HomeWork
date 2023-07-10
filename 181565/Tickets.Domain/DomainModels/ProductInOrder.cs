using System;

namespace Tickets.Domain.DomainModels
{
    public class ProductInOrder : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Product ProductTicket { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}