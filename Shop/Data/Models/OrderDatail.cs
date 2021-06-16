using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDatail
    {


        public int id { get; set; }
        public int orderId { get; set; }
        public int drugId { get; set; }
        public uint price { get; set; }

        public virtual Medicines drug { get; set; }
        
        public virtual Order order { get; set; }
    
    
       
    }
}
