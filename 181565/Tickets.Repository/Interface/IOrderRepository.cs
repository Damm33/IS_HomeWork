
using System;
using System.Collections.Generic;
using System.Text;
using Tickets.Domain.DomainModels;

namespace Tickets.Repository.Interface
{
    public interface IOrderRepository
    {
        Order getOrderDetails(Guid id);
        List<Order> getAllOrders(string id);
        public void Insert(Order o);
        List<Order> getOrderDetails(string id);
        List<Order> getAllOrders();
    }
}
