using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BeerXML.Models;
using BeerXML.CustomValidation;
using System.Xml.Serialization;
using System.IO;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeerXML.Controllers
{
    public class DisplayController : Controller
    {
        private BeerXmlContext db = new BeerXmlContext();


        public IActionResult Index()
        {
            
            Yeast yeast = db.Yeast.FirstOrDefault();
            Equipment equipment = db.Equipment.FirstOrDefault();
            Mash mash = db.Mash.FirstOrDefault();
            Style style = db.Style.FirstOrDefault();

            Recipe recipe = db.Recipes.FirstOrDefault();
            List<Recipe> recipes = db.Recipes.ToList();

            return View(recipes);
        }

        public FileResult Recipe(int id)
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
            rvm.Recipe.Waters.Add(rvm.Water);
            rvm.Recipe.Hops.Add(rvm.Hop);
            rvm.Recipe.Equipments.Add(rvm.Equipment);
            rvm.Recipe.Fermentables.Add(rvm.Fermentable);
            rvm.Recipe.Mashs.Add(rvm.Mash);
            foreach (var item in rvm.MashSteps)
            {
                rvm.Mash.MashSteps.Add(item);
            }
            rvm.Recipe.Miscs.Add(rvm.Misc);     
            rvm.Recipe.Yeasts.Add(rvm.Yeast);
            rvm.Recipe.Style = rvm.Style;



            // serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Recipe));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, rvm.Recipe);
            writer.Close();

            var contentType = "text/xml";
            var content = sb.ToString();
            var bytes = Encoding.UTF8.GetBytes(content);
            var result = new FileContentResult(bytes, contentType);
            result.FileDownloadName = rvm.Recipe.Name + ".xml";
            return result;

            //byte[] fileBytes = System.IO.File.ReadAllBytes(sb.ToString());
            //string fileName = rvm.Recipe.Name + ".xml";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            //return View(rvm);
        }
    }
}
