using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    //Серцево-сцудинні, протизастудні, дерматологічні, вітаміни, антибактеріальні, опорно-рухова система, стоматологічні, неврологічні
   
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Medicines> drugs { get; set; }

    }
}
