using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BeerXML.Models;

namespace BeerXML.Migrations
{
    [DbContext(typeof(BeerXmlContext))]
    partial class BeerXmlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerXML.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BatchSize");

                    b.Property<double>("BoilSize");

                    b.Property<double>("BoilTime");

                    b.Property<bool>("CalcBoilVolume");

                    b.Property<double>("EvapRate");

                    b.Property<double>("HopUtilization");

                    b.Property<double>("LauterDeadspace");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("TopUpKettle");

                    b.Property<double>("TopUpWater");

                    b.Property<double>("TrubChillerLoss");

                    b.Property<double>("TunSpecificHeat");

                    b.Property<double>("TunVolume");

                    b.Property<double>("TunWeight");

                    b.Property<double>("Version");

                    b.HasKey("EquipmentId");
                });

            modelBuilder.Entity("BeerXML.Models.EquipmentRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("EquipmentId");

                    b.HasKey("RecipeId", "EquipmentId");
                });

            modelBuilder.Entity("BeerXML.Models.Fermentable", b =>
                {
                    b.Property<int>("FermentableId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AddAfterBoil");

                    b.Property<double>("Amount");

                    b.Property<double>("CoarseFineDiff");

                    b.Property<double>("Color");

                    b.Property<double>("DiastaticPower");

                    b.Property<double>("IbuGalPerLb");

                    b.Property<double>("MaxInBatch");

                    b.Property<double>("Moisture");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Origin");

                    b.Property<double>("Protein");

                    b.Property<double>("RecommendedMash");

                    b.Property<string>("Supplier");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<double>("Version");

                    b.Property<double>("Yeld");

                    b.HasKey("FermentableId");
                });

            modelBuilder.Entity("BeerXML.Models.FermentableRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("FermentableId");

                    b.HasKey("RecipeId", "FermentableId");
                });

            modelBuilder.Entity("BeerXML.Models.Hop", b =>
                {
                    b.Property<int>("HopId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Alpha");

                    b.Property<double>("Amount");

                    b.Property<double>("Beta");

                    b.Property<double>("Caryophyllene");

                    b.Property<double>("Cohumulone");

                    b.Property<string>("Form");

                    b.Property<double>("HSI");

                    b.Property<double>("Humulene");

                    b.Property<double>("Myrcene");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Origin");

                    b.Property<string>("Substitutes");

                    b.Property<double>("Time");

                    b.Property<string>("Type");

                    b.Property<string>("Use")
                        .IsRequired();

                    b.Property<double>("Version");

                    b.HasKey("HopId");
                });

            modelBuilder.Entity("BeerXML.Models.HopRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("HopId");

                    b.HasKey("RecipeId", "HopId");
                });

            modelBuilder.Entity("BeerXML.Models.Mash", b =>
                {
                    b.Property<int>("MashId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EquipAdjust");

                    b.Property<double>("GrainTemp");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("Ph");

                    b.Property<double>("SpargeTemp");

                    b.Property<double>("TunTemp");

                    b.Property<double>("TunWeight");

                    b.Property<double>("TunspecificHeat");

                    b.Property<double>("Version");

                    b.HasKey("MashId");
                });

            modelBuilder.Entity("BeerXML.Models.MashRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("MashId");

                    b.HasKey("RecipeId", "MashId");
                });

            modelBuilder.Entity("BeerXML.Models.MashStep", b =>
                {
                    b.Property<int>("MashStepId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("EndTemp");

                    b.Property<double>("InfuseAmount");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("RampTime");

                    b.Property<double>("StepTemp");

                    b.Property<double>("StepTime");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<double>("Version");

                    b.HasKey("MashStepId");
                });

            modelBuilder.Entity("BeerXML.Models.MashStepMash", b =>
                {
                    b.Property<int>("MashId");

                    b.Property<int>("MashStepId");

                    b.HasKey("MashId", "MashStepId");
                });

            modelBuilder.Entity("BeerXML.Models.Misc", b =>
                {
                    b.Property<int>("MiscId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<bool>("AmountIsWeight");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("Time");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Use")
                        .IsRequired();

                    b.Property<string>("UseFor");

                    b.Property<double>("Version");

                    b.HasKey("MiscId");
                });

            modelBuilder.Entity("BeerXML.Models.MiscRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("MiscId");

                    b.HasKey("RecipeId", "MiscId");
                });

            modelBuilder.Entity("BeerXML.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Age");

                    b.Property<double>("AgeTemp");

                    b.Property<string>("AsstBrewer");

                    b.Property<double>("BatchSize");

                    b.Property<double>("BoilSize");

                    b.Property<double>("BoilTime");

                    b.Property<string>("Brewer")
                        .IsRequired();

                    b.Property<double>("Carbonation");

                    b.Property<double>("CarbonationTemp");

                    b.Property<string>("Date");

                    b.Property<double>("Efficiency");

                    b.Property<double>("FG");

                    b.Property<double>("FermentationStages");

                    b.Property<bool>("ForcedCarbonation");

                    b.Property<double>("KegPrimingFactor");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("OG");

                    b.Property<double>("PrimaryAges");

                    b.Property<double>("PrimaryTemp");

                    b.Property<double>("PrimingSugarEquiv");

                    b.Property<string>("PrimingSugarName");

                    b.Property<double>("SecondaryAge");

                    b.Property<double>("SecondaryTemp");

                    b.Property<int>("StyleId");

                    b.Property<string>("TasteNotes");

                    b.Property<double>("TasteRating");

                    b.Property<double>("TertiaryAge");

                    b.Property<double>("TertiaryTemp");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<double>("Version");

                    b.HasKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AbvMax");

                    b.Property<double>("AbvMin");

                    b.Property<double>("CarbMax");

                    b.Property<double>("CarbMin");

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("CategoryNumber")
                        .IsRequired();

                    b.Property<double>("ColorMax");

                    b.Property<double>("ColorMin");

                    b.Property<string>("Examples");

                    b.Property<double>("FgMax");

                    b.Property<double>("FgMin");

                    b.Property<double>("IbuMax");

                    b.Property<double>("IbuMin");

                    b.Property<string>("Ingredients");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("OgMax");

                    b.Property<double>("OgMin");

                    b.Property<string>("Profile");

                    b.Property<string>("StyleGuide")
                        .IsRequired();

                    b.Property<string>("StyleLetter")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.HasKey("StyleId");
                });

            modelBuilder.Entity("BeerXML.Models.Water", b =>
                {
                    b.Property<int>("WaterId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<double>("Bicarbonate");

                    b.Property<double>("Calcium");

                    b.Property<double>("Chloride");

                    b.Property<double>("Magnesium");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("Ph");

                    b.Property<double>("Sodium");

                    b.Property<double>("Sulfate");

                    b.Property<int>("Version");

                    b.HasKey("WaterId");
                });

            modelBuilder.Entity("BeerXML.Models.WaterRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("WaterId");

                    b.HasKey("RecipeId", "WaterId");
                });

            modelBuilder.Entity("BeerXML.Models.Yeast", b =>
                {
                    b.Property<int>("YeastId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AddToSecondary");

                    b.Property<float>("Amount");

                    b.Property<bool>("AmountIsWeight");

                    b.Property<float>("Attenuation");

                    b.Property<string>("BestFor");

                    b.Property<string>("Flocculation");

                    b.Property<string>("Form")
                        .IsRequired();

                    b.Property<string>("Laboratory");

                    b.Property<int>("MaxReuse");

                    b.Property<float>("MaxTemperature");

                    b.Property<float>("MinTemperature");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("ProductID");

                    b.Property<int>("TimesCultured");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.HasKey("YeastId");
                });

            modelBuilder.Entity("BeerXML.Models.YeastRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("YeastId");

                    b.HasKey("RecipeId", "YeastId");
                });

            modelBuilder.Entity("BeerXML.Models.EquipmentRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");

                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.FermentableRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Fermentable")
                        .WithMany()
                        .HasForeignKey("FermentableId");

                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.HopRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Hop")
                        .WithMany()
                        .HasForeignKey("HopId");

                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.MashRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Mash")
                        .WithMany()
                        .HasForeignKey("MashId");

                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.MashStepMash", b =>
                {
                    b.HasOne("BeerXML.Models.Mash")
                        .WithMany()
                        .HasForeignKey("MashId");

                    b.HasOne("BeerXML.Models.MashStep")
                        .WithMany()
                        .HasForeignKey("MashStepId");
                });

            modelBuilder.Entity("BeerXML.Models.MiscRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Misc")
                        .WithMany()
                        .HasForeignKey("MiscId");

                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.Recipe", b =>
                {
                    b.HasOne("BeerXML.Models.Style")
                        .WithMany()
                        .HasForeignKey("StyleId");
                });

            modelBuilder.Entity("BeerXML.Models.WaterRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("BeerXML.Models.Water")
                        .WithMany()
                        .HasForeignKey("WaterId");
                });

            modelBuilder.Entity("BeerXML.Models.YeastRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("BeerXML.Models.Yeast")
                        .WithMany()
                        .HasForeignKey("YeastId");
                });
        }
    }
}
