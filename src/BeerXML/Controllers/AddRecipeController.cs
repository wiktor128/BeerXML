using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BeerXML.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeerXML.Controllers
{
    public class AddRecipeController : Controller
    {
        private BeerXmlContext db = new BeerXmlContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Water> waters = db.Waters.ToList();
            List<Recipe> recipes = db.Recipes.ToList();
            return View();
        }
        
        //[HttpPost]
        //public IActionResult Index(RecipeViewModel recipe)
        //{
        //    db.Recipes.Add(recipe.Recipe);
        //    db.Waters.Add(recipe.Water);

        //    db.SaveChanges();

        //    return View();
        //}

        [HttpPost]
        public IActionResult Index(RecipeViewModel recipeViewModel)
        {
            var recipeEnt = db.Recipes.Add(recipeViewModel.Recipe).Entity;
            var waterEnt = db.Waters.Add(recipeViewModel.Water).Entity;

            db.WatersRecipes.Add(new WaterRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeID,
                Water = waterEnt,
                WaterId = waterEnt.WaterId
            });

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

            return View();
        }
    }
}
