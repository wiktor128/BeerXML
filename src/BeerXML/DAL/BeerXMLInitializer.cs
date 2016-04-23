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

            if (!context.Waters.Any())
            {
                //var austen = context.Authors.Add(
                //    new Author { LastName = "Austen", FirstName = "Jane" }).Entity;
                context.Waters.AddRange(
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
                        // public List<WaterRecipe> WaterRecipes { get; set; }
                    }
                );

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
