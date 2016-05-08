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
        public DbSet<HopRecipe> HopRecipes { get; set; }

        public DbSet<Fermentable> Fermentable { get; set; }
        public DbSet<FermentableRecipe> FermentableRecipes { get; set; }

        public DbSet<Yeast> Yeast { get; set; }
        public DbSet<YeastRecipe> YeastRecipe { get; set; }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentRecipe> EquipmentRecipe { get; set; }

        public DbSet<Misc> Misc { get; set; }
        public DbSet<MiscRecipe> MiscRecipe { get; set; }

        public DbSet<Style> Style { get; set; }

        public DbSet<Mash> Mash { get; set; }
        public DbSet<MashStep> MashStep { get; set; }
        public DbSet<MashStepMash> MashStepMash { get; set; }

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

//---- FermentableRecipe ----
            modelBuilder.Entity<FermentableRecipe>()
                .HasKey(fr => new { fr.RecipeId, fr.FermentableId });

            modelBuilder.Entity<FermentableRecipe>()
                .HasOne(fr => fr.Recipe)
                .WithMany(r => r.FermentableRecipe)
                .HasForeignKey(fr => fr.RecipeId);

            modelBuilder.Entity<FermentableRecipe>()
                .HasOne(fr => fr.Fermentable)
                .WithMany(f => f.FermentableRecipe)
                .HasForeignKey(fr => fr.FermentableId);

//---- YeastRecipe ----
            modelBuilder.Entity<YeastRecipe>()
                .HasKey(yr => new { yr.RecipeId, yr.YeastId });

            modelBuilder.Entity<YeastRecipe>()
                .HasOne(yr => yr.Recipe)
                .WithMany(r => r.YeastRecipe)
                .HasForeignKey(yr => yr.RecipeId);

            modelBuilder.Entity<YeastRecipe>()
                .HasOne(yr => yr.Yeast)
                .WithMany(y => y.YeastRecipe)
                .HasForeignKey(yr => yr.YeastId);

//---- MiscRecipe ----
            modelBuilder.Entity<MiscRecipe>()
                .HasKey(mr => new { mr.RecipeId, mr.MiscId });

            modelBuilder.Entity<MiscRecipe>()
                .HasOne(mr => mr.Recipe)
                .WithMany(r => r.MiscRecipe)
                .HasForeignKey(mr => mr.RecipeId);

            modelBuilder.Entity<MiscRecipe>()
                .HasOne(mr => mr.Misc)
                .WithMany(m => m.MiscRecipe)
                .HasForeignKey(mr => mr.MiscId);

//---- EquipmentRecipe ----
            modelBuilder.Entity<EquipmentRecipe>()
                .HasKey(er => new { er.RecipeId, er.EquipmentId });

            modelBuilder.Entity<EquipmentRecipe>()
                .HasOne(er => er.Recipe)
                .WithMany(r => r.EquipmentRecipe)
                .HasForeignKey(er => er.RecipeId);

            modelBuilder.Entity<EquipmentRecipe>()
                .HasOne(er => er.Equipment)
                .WithMany(e => e.EquipmentRecipe)
                .HasForeignKey(er => er.EquipmentId);

//---- MashStepMash ----
            modelBuilder.Entity<MashStepMash>()
                .HasKey(msm => new { msm.MashId, msm.MashStepId });

            modelBuilder.Entity<MashStepMash>()
                .HasOne(msm => msm.Mash)
                .WithMany(m => m.MashStepMash)
                .HasForeignKey(msm => msm.MashId);

            modelBuilder.Entity<MashStepMash>()
                .HasOne(msm => msm.MashStep)
                .WithMany(ms => ms.MashStepMash)
                .HasForeignKey(msm => msm.MashStepId);

//---- MashRecipe ----
            modelBuilder.Entity<MashRecipe>()
                .HasKey(mr => new { mr.RecipeId, mr.MashId });

            modelBuilder.Entity<MashRecipe>()
                .HasOne(mr => mr.Recipe)
                .WithMany(r => r.MashRecipe)
                .HasForeignKey(mr => mr.RecipeId);

            modelBuilder.Entity<MashRecipe>()
                .HasOne(mr => mr.Mash)
                .WithMany(e => e.MashRecipe)
                .HasForeignKey(mr => mr.MashId);

            //---- Style -----
            //modelBuilder.Entity<Style>()
            //    .HasMany(s => s.Recipes)
            //    .WithOne(r => r.Style);


        }// still not sure how it works xD

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Startup.Configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
}
