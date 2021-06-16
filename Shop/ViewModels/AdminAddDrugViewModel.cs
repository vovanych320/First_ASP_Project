using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Models;
using System.ComponentModel.DataAnnotations;
using Shop.Data.Models;
using Shop.ViewModels;


namespace Shop.ViewModels
{
    public class AdminAddDrugViewModel
    {

        public string description { get; set; }
        public string producer { get; set; }
        public ushort price { get; set; }
        public string name { get; set; }
        public string doze { get; set; }
        public string volume { get; set; }
        public string img { get; set; }//refference to the picture
        public bool available { get; set; }
        public bool isFavorite { get; set; }
        public virtual Category Category { set; get; }
    }
}
