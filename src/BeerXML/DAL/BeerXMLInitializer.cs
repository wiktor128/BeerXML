using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using BeerXML.Models;

namespace BeerXML.DAL
{
    public class BeerXMLInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<BeerXmlContext>(); // this problem was solved by adding dependency injection

            context.Database.Migrate();

            if (!context.Waters.Any() && !context.Recipes.Any())
            {
                var exampleWater = context.Waters.Add(
                    new Water
                    {
                        //WaterId = 1,
                        Name = "Aqua",
                        Version = 2,
                        Amount = 15,
                        Calcium = 990,
                        Bicarbonate = 8768,
                        Sulfate = 6786,
                        Chloride = 678678,
                        Sodium = 2345,
                        Magnesium = 345,
                        Ph = 4,
                        Notes = "Better than tap water."
                        //WaterRecipes
                    }
                ).Entity;

                var exampleRecipe = context.Recipes.Add(
                    new Recipe
                    {
                      //RecipeID = ,
                        Name = "Cheap Beer",
                        Version = 1,
                        Type = "Grain",
                        Brewer = "Me",
                        AsstBrewer = "None",
                        BatchSize = 111,
                        BoilSize = 11,
                        BoilTime = 11,
                        Efficiency = 1,
                     // WaterRecipes = ,
                        Notes = "Good for breakfast",
                        TasteNotes = "It taste like mushrooms",
                        TasteRating = 10,
                        OG = 12,
                        FG = 2,
                        FermentationStages = 2,
                        PrimaryAges = 23,
                        PrimaryTemp = 32,
                        SecondaryAge = 653,
                        SecondaryTemp = 346,
                        TertiaryAge = 346,
                        TertiaryTemp = 346,
                        Age = 23,
                        AgeTemp = 33,
                        Date = DateTime.Today.ToString(),
                        Carbonation = 90,
                        ForcedCarbonation = false,
                        PrimingSugarName = "Diamant",
                        CarbonationTemp = 44,
                        PrimingSugarEquiv = 3,
                        KegPrimingFactor = 3
                    }
                ).Entity;

                var exampleWatersRecipes = context.WatersRecipes.Add(
                    new WaterRecipe
                    {
                        Recipe = exampleRecipe,
                        RecipeId = exampleRecipe.RecipeId,
                        Water = exampleWater,
                        WaterId = exampleWater.WaterId
                    }
                ).Entity;

                //exampleRecipe.WaterRecipe = exampleWatersRecipes;
          
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}
