using Microsoft.AspNetCore.Mvc.Abstractions;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDbCont;
        private readonly ShopCart shopCart;
      

        public OrdersRepository(AppDBContent appDb, ShopCart sC)
        {
            this.appDbCont = appDb;
            this.shopCart = sC;
        }

        public IEnumerable<Order> getAllOrdersFromDb => appDbCont.Order.Include(i => i.orderNumber);

        public IEnumerable<OrderDatail> dets => appDbCont.OrderDetail; 

        public IEnumerable<Medicines> drugsInOneOrder => appDbCont.Drug;

        //public IEnumerable<Medicines> getDrugs(List<OrderDatail> d)
        //{
        //    IEnumerable<Medicines> m = appDbCont.Drug.Where(i => i.)
        //}

        public void createOrder(Order order, int ordNumId)
        {
            order.orderTime = DateTime.Now;
            order.orderNumber = ordNumId;
            appDbCont.Order.Add(order);
            appDbCont.SaveChanges();


            var items = shopCart.listShopItem;

            foreach(var el in items)
            {
            
                var orderDetail = new OrderDatail
                {
                    drugId = el.drug.id,
                    orderId = order.id,
                    price = el.drug.price
                };


                appDbCont.OrderDetail.Add(orderDetail);
            }

            appDbCont.SaveChanges();
        }


        public IEnumerable<Medicines> getDrug(OrderDatail c)
        {
            return appDbCont.Drug.Where(i => i.id == c.orderId);
        }

    }
}
