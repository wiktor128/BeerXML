using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
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

            if (context.Database.AsRelational())
            {

            }
        }
        //protected override void Seed(BeerXmlContext)
        //{
        //    List<Water> waters = new List<Water>
        //    {
        //        new Water
        //        {
        //            WaterId = 1,
        //            Name = "Aqua",
        //            Version = 2,
        //            Amount = 100,
        //            Calcium = 10,
        //            Bicarbonate = 1,
        //            Sulfate = 400,
        //            Chloride = 29,
        //            Sodium = 34,
        //            Magnesium = 35,
        //            Ph = 3425,
        //            Notes = "Better than tap water"
        //            //public List<WaterRecipe> WaterRecipes { get; set; }
        //        }
        //    }
        //}
    }
}
