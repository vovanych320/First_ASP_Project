using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using Shop.Data.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IMedicines AllDrugs;
        private readonly ICategory AllCategories;

        public MedicinesController(IMedicines IAllDrugs, ICategory ICategories)
        {
            AllDrugs = IAllDrugs;
            AllCategories = ICategories;
        }

        [Route("Medicines/List")]
        [Route("Medicines/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Medicines> drugs = null;
            string currCat = "";
            if (string.IsNullOrEmpty(category))
            {
                drugs = AllDrugs.drugs.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("hearts", category, StringComparison.OrdinalIgnoreCase))
                {
                    drugs = AllDrugs.drugs.Where(i => i.categoryID.Equals(1)).OrderBy(i => i.id);
                }
                else if (string.Equals("anti_cold", category, StringComparison.OrdinalIgnoreCase))
                {
                    drugs = AllDrugs.drugs.Where(i => i.categoryID.Equals(2)).OrderBy(i => i.id);
                }
                else if (string.Equals("dermatological", category, StringComparison.OrdinalIgnoreCase))
                {
                    drugs = AllDrugs.drugs.Where(i => i.categoryID.Equals(3)).OrderBy(i => i.id);
                }
                else if (string.Equals("vitamins", category, StringComparison.OrdinalIgnoreCase))
                {
                    drugs = AllDrugs.drugs.Where(i => i.categoryID.Equals(4)).OrderBy(i => i.id);
                }
                else if (string.Equals("anti_bacteries", category, StringComparison.OrdinalIgnoreCase))
                {
                    drugs = AllDrugs.drugs.Where(i => i.categoryID.Equals(5)).OrderBy(i => i.id);
                }
                else if (string.Equals("neurological", category, StringComparison.OrdinalIgnoreCase))
                {
                    drugs = AllDrugs.drugs.Where(i => i.categoryID.Equals(6)).OrderBy(i => i.id);
                }

                currCat = _category;
            }

            var drugObject = new MedicinesListNewModel
            {
                allDrugs = drugs,
                currCategory = currCat
            };

            //Серцево-сцудинні, протизастудні, дерматологічні, 
            //вітаміни, антибактеріальні, опорно-рухова система, стоматологічні, неврологічні


            ViewBag.Title = "Medicines Page";

            return View(drugObject);
        }

    }
}
