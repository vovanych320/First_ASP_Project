using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;


namespace Shop.Controllers
{

    [Authorize(Roles ="admin")]
    public class AdministrationController : Controller
    {
        private readonly AppDBContent db;

        public AdministrationController(AppDBContent db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult AdminAddDrug()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult AdminAddDrug(Medicines drug)
        {
            if(ModelState.IsValid)
            {
                var addDrug = new Medicines
                {
                    available = drug.available,
                    categoryID = drug.categoryID,
                    description = drug.description,
                    doze = drug.doze,
                    img = drug.img,
                    isFavorite = drug.isFavorite,
                    name = drug.name,
                    price = drug.price,
                    producer = drug.producer,
                    volume = drug.volume
                };
                db.Add<Medicines>(addDrug);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}