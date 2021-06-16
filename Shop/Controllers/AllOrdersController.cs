using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class AllOrdersController : Controller
    {
        
        public readonly IAllOrders allOrders;

        public AllOrdersController(IAllOrders ord )
        {
            this.allOrders = ord;
           
        }

        public IActionResult Index()
        {

            IEnumerable<Order> orders = allOrders.getAllOrdersFromDb;
            IEnumerable<OrderDatail> details = allOrders.dets;
           

            var orderObj = new AllOrdersViewModel
            {
                allOrders = orders,
                orDetails = details
            };


            return View(orderObj);
        }
    }
}