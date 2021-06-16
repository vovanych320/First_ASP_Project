using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IMedicines _drugRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IMedicines dRep, ShopCart shCart)
        {
            _drugRep = dRep;
            _shopCart = shCart;
        }



        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItem = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }


        public RedirectToActionResult addToCart(int id)
        {
            var item = _drugRep.drugs.FirstOrDefault(i => i.id==id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

    }
}