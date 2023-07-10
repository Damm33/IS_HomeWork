
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tickets.Domain.DomainModels;
using Tickets.Repository.Interface;

namespace Tickets.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
  
        public List<Order> getAllOrders(string id)
        {
            throw new NotImplementedException();
        }

        public List<Order> getAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order getOrderDetails(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrderDetails(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order o)
        {
            throw new NotImplementedException();
        }
    }
}
