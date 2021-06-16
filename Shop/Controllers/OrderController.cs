using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        private static int num = 1;

        public OrderController(IAllOrders alOd, ShopCart sC)
        {
            this.allOrders = alOd;
            this.shopCart = sC;
        }



        public IActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopItem = shopCart.getShopItems();

            if(shopCart.listShopItem.Count ==0)
            {
                ModelState.AddModelError("", "У вас повинні бути товари");
            }

            if(ModelState.IsValid)
            {
                allOrders.createOrder(order,num);
                num++;
                if (order.isByСourier)
                {
                    
                    return RedirectToAction("CompleteByCourier");
                }
                else
                {
                    return RedirectToAction("CompleteBySelf");
                }
            }
            
            return View(order);
        }

        public IActionResult CompleteByCourier()
        {
            ViewBag.Message = num.ToString();
           
            return View();
        }

        public IActionResult CompleteBySelf()
        {
            ViewBag.Message = num.ToString();
            
            return View();
        }

    }
}