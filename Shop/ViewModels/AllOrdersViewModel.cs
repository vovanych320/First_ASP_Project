using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class AllOrdersViewModel
    {

        //public Order order { get; set; }
        public IEnumerable<Order> allOrders { get; set; }
        public IEnumerable<OrderDatail> orDetails { get; set; }
    }
}
