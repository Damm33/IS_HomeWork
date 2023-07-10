using Tickets.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }

        public TicketsApplicationUser User { get; set; }

        public virtual List<ProductInOrder> Tickets { get; set; }
    }
}
