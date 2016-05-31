using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BeerXML.Models;
using BeerXML.CustomValidation;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeerXML.Controllers
{
    public class DisplayController : Controller
    {
        private BeerXmlContext db = new BeerXmlContext();


        public IActionResult Index()
        {
            List<Recipe> recipes = db.Recipes.ToList();

            return View(recipes);
        }

        public IActionResult Recipe(int id)
        {
            RecipeViewModel rvm = new RecipeViewModel();

            rvm.Recipe = db.Recipes
                            .Where(r => r.RecipeId == id)
                            .FirstOrDefault();

            rvm.Water = db.Waters
                            .Where(w => w.WaterId ==
                                db.WatersRecipes
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().WaterId)
                            .FirstOrDefault();

            rvm.Hop = db.Hops
                            .Where(h => h.HopId ==
                                db.HopRecipes
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().HopId)
                            .FirstOrDefault();

            rvm.Equipment = db.Equipment
                            .Where(e => e.EquipmentId ==
                                db.EquipmentRecipe
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().EquipmentId)
                            .FirstOrDefault();

            rvm.Fermentable = db.Fermentable
                            .Where(f => f.FermentableId ==
                                db.FermentableRecipes
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().FermentableId)
                            .FirstOrDefault();

            rvm.Mash = db.Mash
                            .Where(m => m.MashId ==
                                db.MashRecipe
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().MashId)
                            .FirstOrDefault();

            rvm.MashSteps = db.MashStep
                            .Where(ms => ms.MashStepId ==
                                db.MashStepMash
                                    .Where(wr => wr.MashId == rvm.Mash.MashId)
                                    .FirstOrDefault().MashStepId)
                            .ToList();

            rvm.Misc = db.Misc
                            .Where(m => m.MiscId ==
                                db.MiscRecipe
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().MiscId)
                            .FirstOrDefault();

            rvm.Yeast = db.Yeast
                            .Where(m => m.YeastId ==
                                db.YeastRecipe
                                    .Where(wr => wr.RecipeId == id)
                                    .FirstOrDefault().YeastId)
                            .FirstOrDefault();

            //rvm.Style = db.Style
            //                .Where(m => m.MashId ==
            //                    db.MashRecipe
            //                        .Where(wr => wr.RecipeId == id)
            //                        .FirstOrDefault().MashId)
            //                .FirstOrDefault();
            rvm.Style = rvm.Recipe.Style;



            return View(rvm);
        }
    
    }
}
