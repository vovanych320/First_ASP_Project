using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order, int ordNumId);
        IEnumerable<Order> getAllOrdersFromDb { get; }

        public IEnumerable<OrderDatail> dets { get; }

        public IEnumerable<Medicines> getDrug(OrderDatail c);

        IEnumerable<Medicines> drugsInOneOrder { get; }
        //List<OrderDatail> orderDetails { get; }
    }
}
