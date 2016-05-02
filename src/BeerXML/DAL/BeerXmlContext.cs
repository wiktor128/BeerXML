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
        public DbSet<WaterRecipe> WatersRecipes { get; set; }

        public DbSet<Hop> Hops { get; set; }
        public DbSet<HopRecipe> HopRecipe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //base.OnModelCreating(modelBuilder);


            //---- WaterRecipe ----
            modelBuilder.Entity<WaterRecipe>()
                .HasKey(wr => new { wr.RecipeId, wr.WaterId });

            modelBuilder.Entity<WaterRecipe>()
                .HasOne(wr => wr.Recipe)
                .WithMany(r => r.WaterRecipe)
                .HasForeignKey(wr => wr.RecipeId);

            modelBuilder.Entity<WaterRecipe>()
                .HasOne(wr => wr.Water)
                .WithMany(w => w.WaterRecipe)
                .HasForeignKey(wr => wr.WaterId);

            //---- HopRecipe ----
            modelBuilder.Entity<HopRecipe>()
                .HasKey(hr => new { hr.RecipeId, hr.HopId });

            modelBuilder.Entity<HopRecipe>()
                .HasOne(hr => hr.Recipe)
                .WithMany(r => r.HopRecipe)
                .HasForeignKey(hr => hr.RecipeId);

            modelBuilder.Entity<HopRecipe>()
                .HasOne(hr => hr.Hop)
                .WithMany(h => h.HopRecipe)
                .HasForeignKey(hr => hr.HopId);


        }// still not sure how it works xD

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Startup.Configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
}
