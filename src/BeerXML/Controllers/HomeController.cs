using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BeerXML.Models;

namespace BeerXML.Controllers
{
    public class HomeController : Controller
    {
        private BeerXmlContext db = new BeerXmlContext();

        public IActionResult Index()
        {
            List<Water> waters = db.Waters.ToList();
            List<Recipe> recipes = db.Recipes.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
