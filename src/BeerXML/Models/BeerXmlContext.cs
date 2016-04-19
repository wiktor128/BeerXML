using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace BeerXML.Models
{
    public class BeerXmlContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Water> Waters { get; set; }
    }
}
