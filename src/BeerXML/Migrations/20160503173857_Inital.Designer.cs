using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BeerXML.Models;

namespace BeerXML.Migrations
{
    [DbContext(typeof(BeerXmlContext))]
    [Migration("20160503173857_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerXML.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("BatchSize");

                    b.Property<float>("BoilSize");

                    b.Property<float>("BoilTime");

                    b.Property<bool>("CalcBoilVolume");

                    b.Property<float>("EvapRate");

                    b.Property<float>("HopUtilization");

                    b.Property<float>("LauterDeadspace");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<float>("TopUpKettle");

                    b.Property<float>("TopUpWater");

                    b.Property<float>("TrubChillerLoss");

                    b.Property<float>("TunSpecificHeat");

                    b.Property<float>("TunVolume");

                    b.Property<float>("TunWeight");

                    b.Property<int>("Version");

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

                    b.Property<float>("Amount");

                    b.Property<float>("CoarseFineDiff");

                    b.Property<float>("Color");

                    b.Property<float>("DiastaticPower");

                    b.Property<float>("IbuGalPerLb");

                    b.Property<float>("MaxInBatch");

                    b.Property<float>("Moisture");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Origin");

                    b.Property<float>("Protein");

                    b.Property<float>("RecommendedMash");

                    b.Property<string>("Supplier");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.Property<float>("Yeld");

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

                    b.Property<float>("Alpha");

                    b.Property<float>("Amount");

                    b.Property<float>("Beta");

                    b.Property<float>("Caryophyllene");

                    b.Property<float>("Cohumulone");

                    b.Property<string>("Form");

                    b.Property<float>("HSI");

                    b.Property<float>("Humulene");

                    b.Property<float>("Myrcene");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Origin");

                    b.Property<string>("Substitutes");

                    b.Property<int>("Time");

                    b.Property<string>("Type");

                    b.Property<string>("Use")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.HasKey("HopId");
                });

            modelBuilder.Entity("BeerXML.Models.HopRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("HopId");

                    b.HasKey("RecipeId", "HopId");
                });

            modelBuilder.Entity("BeerXML.Models.Misc", b =>
                {
                    b.Property<int>("MiscId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<bool>("AmountIsWeight");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<int>("Time");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Use")
                        .IsRequired();

                    b.Property<string>("UseFor");

                    b.Property<int>("Version");

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

                    b.Property<int>("Age");

                    b.Property<float>("AgeTemp");

                    b.Property<string>("AsstBrewer");

                    b.Property<float>("BatchSize");

                    b.Property<float>("BoilSize");

                    b.Property<int>("BoilTime");

                    b.Property<string>("Brewer")
                        .IsRequired();

                    b.Property<float>("Carbonation");

                    b.Property<float>("CarbonationTemp");

                    b.Property<string>("Date");

                    b.Property<float>("Efficiency");

                    b.Property<double>("FG");

                    b.Property<int>("FermentationStages");

                    b.Property<bool>("ForcedCarbonation");

                    b.Property<float>("KegPrimingFactor");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("OG");

                    b.Property<int>("PrimaryAges");

                    b.Property<float>("PrimaryTemp");

                    b.Property<float>("PrimingSugarEquiv");

                    b.Property<string>("PrimingSugarName");

                    b.Property<int>("SecondaryAge");

                    b.Property<float>("SecondaryTemp");

                    b.Property<int?>("StyleStyleId");

                    b.Property<string>("TasteNotes");

                    b.Property<float>("TasteRating");

                    b.Property<int>("TertiaryAge");

                    b.Property<float>("TertiaryTemp");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.HasKey("RecipeId");
                });

            modelBuilder.Entity("BeerXML.Models.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AbvMax");

                    b.Property<float>("AbvMin");

                    b.Property<float>("CarbMax");

                    b.Property<float>("CarbMin");

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("CategoryNumber")
                        .IsRequired();

                    b.Property<float>("ColorMax");

                    b.Property<float>("ColorMin");

                    b.Property<string>("Examples");

                    b.Property<float>("FgMax");

                    b.Property<float>("FgMin");

                    b.Property<float>("IbuMax");

                    b.Property<float>("IbuMin");

                    b.Property<string>("Ingredients");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<float>("OgMax");

                    b.Property<float>("OgMin");

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

                    b.Property<float>("Amount");

                    b.Property<float>("Bicarbonate");

                    b.Property<float>("Calcium");

                    b.Property<float>("Chloride");

                    b.Property<float>("Magnesium");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<float>("Ph");

                    b.Property<float>("Sodium");

                    b.Property<float>("Sulfate");

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
                        .HasForeignKey("StyleStyleId");
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
