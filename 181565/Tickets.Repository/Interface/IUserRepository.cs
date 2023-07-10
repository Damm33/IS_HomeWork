using Tickets.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Tickets.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<TicketsApplicationUser> GetAll();
        TicketsApplicationUser Get(string id);
        void Insert(TicketsApplicationUser entity);
        void Update(TicketsApplicationUser entity);
        void Delete(TicketsApplicationUser entity);
    }
}
