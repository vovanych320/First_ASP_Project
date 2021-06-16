using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {

        [BindNever]
        public int id { get; set; }

        [Display(Name ="Введіть ім'я")]
        [StringLength(30)]
        [Required(ErrorMessage ="Довжина імені не менше 5 символів")]
        public string name { get; set; }

        [Display(Name = "Введіть прізвище")]
        [StringLength(30)]
        [Required(ErrorMessage = "Довжина прізвища не менше 5 символів")]
        public string surname { get; set; }

        [Display(Name = "Введіть номер телефону")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Довжина номера не менше 5 символів")]
        public string phone { get; set; }


        private readonly AppDBContent appDBContent;
        public Order(AppDBContent app)
        {
            this.appDBContent = app;
        }


        public Order()
        { 
        
        }

        public DateTime orderTime { get; set; }

        public int orderNumber { get; set; }
      
        [Display(Name = "Кур'єрська доставка")]
        public bool isByСourier { get; set; }

        public List<OrderDatail> orderDetails { get; set; }






        public IEnumerable<Medicines> getDrug(OrderDatail c)
        {
            return appDBContent.Drug.Where(i => i.id == c.drugId);
        }
    }
}
