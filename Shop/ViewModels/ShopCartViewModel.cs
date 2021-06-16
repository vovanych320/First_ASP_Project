using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class ShopCartViewModel
    {



        public int sum(Medicines m, bool isAdd) 
        {

            int sum = 0;
            if (isAdd)
            {
                sum += m.price;
                sumVar = sumVar;
                return 0;
            }
            else
            {
                if((sum -= m.price) < 0)
                {
                    sumVar = 0;
                    return 0;
                }
                else
                {
                    sum -= m.price;
                    sumVar = sum;
                    return 0;
                }
            }
        
        }




        public int sumVar { get; set; }

        public ShopCart shopCart { get; set; }
    }
}
