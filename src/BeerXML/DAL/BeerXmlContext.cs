using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Design;
using BeerXML.Models;

namespace BeerXML.Models
{
    public class BeerXmlContext : DbContext
    {
        //public BeerXmlContext() : base("BeerXmlContext")
        //{               
        //}

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Water> Waters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<WaterRecipe>()
                .HasKey(wr => new { wr.RecipeId, wr.WaterId });

            modelBuilder.Entity<WaterRecipe>()
                .HasOne(wr => wr.Recipe)
                .WithMany(r => r.WaterRecipes)
                .HasForeignKey(wr => wr.RecipeId);

            modelBuilder.Entity<WaterRecipe>()
                .HasOne(wr => wr.Water)
                .WithMany(w => w.WaterRecipes)
                .HasForeignKey(wr => wr.WaterId);
                
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Startup.Configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
}
