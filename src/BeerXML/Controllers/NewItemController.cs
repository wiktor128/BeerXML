using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BeerXML.Models;
using BeerXML.CustomValidation;
using Microsoft.AspNet.Http;
using System.IO;
using System.Xml.Serialization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeerXML.Controllers
{
    public class NewItemController : Controller
    {
        private BeerXmlContext db = new BeerXmlContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Water> waters = db.Waters.ToList();
            //List<Recipe> recipes = db.Recipes.ToList();
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
                RecipeId = recipeEnt.RecipeId,
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

        public IActionResult Water()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Water(Water water)
        {
            if (db.Waters.Any(w => w.Name == water.Name))
            {
                //ViewData["StatusVar"] = "Water with same name currently exist in database.";
                //ViewBag.DialogText = "Water with same name currently exist in database.";
                //ViewBag.DialogValue = "BAD";
                return View();
            }
            else
            {
                try
                {
                    db.Waters.Add(water);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
               // ViewData["StatusVar"] = "Water successfully added.";
                return View();
            }
            
        }

        public IActionResult Hop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Hop(Hop hop)
        {
            if (db.Hops.Any(w => w.Name == hop.Name))
            {
                return View();
            }
            else
            {
                try
                {
                    db.Hops.Add(hop);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }
        }

        public IActionResult Misc()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Misc(Misc misc)
        {
            if (db.Misc.Any(w => w.Name == misc.Name))
            {
                return View();
            }
            else
            {
                try
                {
                    db.Misc.Add(misc);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }
        }

        public IActionResult Style()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Style(Style style)
        {
            if (db.Style.Any(w => w.Name == style.Name))
            {
                return View();
            }
            else
            {
                try
                {
                    db.Style.Add(style);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }
        }

        public IActionResult Yeast()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Yeast(Yeast yeast)
        {
            if (db.Yeast.Any(w => w.Name == yeast.Name))
            {
                return View();
            }
            else
            {
                try
                {
                    db.Yeast.Add(yeast);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }
        }

        public IActionResult Equipment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Equipment(Equipment equipment)
        {
            if (db.Equipment.Any(w => w.Name == equipment.Name))
            {
                return View();
            }
            else
            {
                try
                {
                    db.Equipment.Add(equipment);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }
        }

        public IActionResult Fermentable()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Fermentable(Fermentable fermentable)
        {
            if (db.Fermentable.Any(w => w.Name == fermentable.Name))
            {
                return View();
            }
            else
            {
                try
                {
                    db.Fermentable.Add(fermentable);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }
        }

        public IActionResult Mash()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Mash(MashMashStepViewModel mashMashStepViewModel)
        {
            var mashEnt = db.Mash.Add(mashMashStepViewModel.Mash).Entity;
            foreach (var item in mashMashStepViewModel.MashSteps)
            {
                if (item.Name != null) //  zabezpieczenie z powodu luki w oknie modal js
                {
                    var mashStepEnt = db.MashStep.Add(item).Entity;

                    var mashStepMash = db.MashStepMash.Add(new MashStepMash()
                    {
                        Mash = mashEnt,
                        MashId = mashEnt.MashId,
                        MashStep = mashStepEnt,
                        MashStepId = mashStepEnt.MashStepId
                    }).Entity;
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return View();
        }

        
        [AjaxOnly]
        public IActionResult MashStepTemplate(int nameAttributeId)
        {
            ViewBag.Id = nameAttributeId;
            var x = View();
            
            return View();
        }

        public IActionResult Recipe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Recipe(RecipeViewModel recipeViewModel)
        {
            var waterEnt = db.Waters.Add(recipeViewModel.Water).Entity;
            var hopEnt = db.Hops.Add(recipeViewModel.Hop).Entity;
            var fermentableEnt = db.Fermentable.Add(recipeViewModel.Fermentable).Entity;
            var yeastEnt = db.Yeast.Add(recipeViewModel.Yeast).Entity;
            var miscEnt = db.Misc.Add(recipeViewModel.Misc).Entity;
            var equipmentEnt = db.Equipment.Add(recipeViewModel.Equipment).Entity;
            var mashEnt = db.Mash.Add(recipeViewModel.Mash).Entity;
            var styleEnt = db.Style.Add(recipeViewModel.Style).Entity;

            recipeViewModel.Recipe.StyleId = styleEnt.StyleId;
            var recipeEnt = db.Recipes.Add(recipeViewModel.Recipe).Entity;

            foreach (var item in recipeViewModel.MashSteps)
            {
                if (item.Name != null) //  zabezpieczenie z powodu luki w oknie modal js
                {
                    var mashStepEnt = db.MashStep.Add(item).Entity;

                    var mashStepMash = db.MashStepMash.Add(new MashStepMash()
                    {
                        Mash = mashEnt,
                        MashId = mashEnt.MashId,
                        MashStep = mashStepEnt,
                        MashStepId = mashStepEnt.MashStepId
                    }).Entity;
                }
            }

            db.WatersRecipes.Add(new WaterRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Water = waterEnt,
                WaterId = waterEnt.WaterId
            });

            db.HopRecipes.Add(new HopRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Hop = hopEnt,
                HopId = hopEnt.HopId
            });

            db.FermentableRecipes.Add(new FermentableRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Fermentable = fermentableEnt,
                FermentableId = fermentableEnt.FermentableId
            });

            db.YeastRecipe.Add(new YeastRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Yeast = yeastEnt,
                YeastId = yeastEnt.YeastId
            });

            db.MiscRecipe.Add(new MiscRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Misc = miscEnt,
                MiscId = miscEnt.MiscId
            });

            db.EquipmentRecipe.Add(new EquipmentRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Equipment = equipmentEnt,
                EquipmentId = equipmentEnt.EquipmentId
            });

            db.MashRecipe.Add(new MashRecipe()
            {
                Recipe = recipeEnt,
                RecipeId = recipeEnt.RecipeId,
                Mash = mashEnt,
                MashId = mashEnt.MashId
            });

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

            return RedirectToAction("Index", "Display");
        }

        public IActionResult RecipeFromFile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecipeFromFile(IFormFile file)
        {

            // file to string
            Stream stream = file.OpenReadStream();
            TextReader streamReader = new StreamReader(stream);
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            // deserialization
            XmlSerializer deserializer = new XmlSerializer(typeof(Recipe));
            StringReader reader = new StringReader(text);
            Recipe recipe = (Recipe)deserializer.Deserialize(reader);
            reader.Close();

            // todo save deserialized object

            return RedirectToAction("Index", "Display");
        }
    }
}
