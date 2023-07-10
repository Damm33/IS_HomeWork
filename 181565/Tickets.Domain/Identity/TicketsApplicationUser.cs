using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Domain.DomainModels;

namespace Tickets.Domain.Identity
{
    public class TicketsApplicationUser : IdentityUser
    {
        public ShoppingCart shoppingCart;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    

    }
}
