using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMedicines _drugRep;


        public HomeController(IMedicines dRep)
        {
            _drugRep = dRep;
        }

       
        public ViewResult Index()
        {
            var homeDrugs = new HomeViewModel
            {
                favDrugs = _drugRep.getFavDrugs
            };
            return View(homeDrugs);
        }

    }
}