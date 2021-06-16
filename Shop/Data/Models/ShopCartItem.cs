using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Medicines drug { get; set; }
        public double price { get; set; }

        public string ShopCartID { get; set; }
    }
}
