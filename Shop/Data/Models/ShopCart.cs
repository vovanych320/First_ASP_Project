using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Providers.Entities;

namespace Shop.Data.Models
{
    public class ShopCart
    {

        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent app)
        {
            this.appDBContent = app;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItem { get; set; }
       

        

        public static ShopCart getCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        

        public void AddToCart(Medicines dr)
        {
            appDBContent.Item.Add(new ShopCartItem
            {
                ShopCartID = ShopCartId,
                drug = dr,
                price = dr.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.Item.Where(c => c.ShopCartID == ShopCartId).Include(s => s.drug).ToList();
        }

    }
}
