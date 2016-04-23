using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BeerXML.Models;

namespace BeerXML.Migrations
{
    [DbContext(typeof(BeerXmlContext))]
    [Migration("20160423182031_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerXML.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
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

                    b.Property<string>("TasteNotes");

                    b.Property<float>("TasteRating");

                    b.Property<int>("TertiaryAge");

                    b.Property<float>("TertiaryTemp");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.HasKey("RecipeID");
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

            modelBuilder.Entity("BeerXML.Models.WaterRecipe", b =>
                {
                    b.HasOne("BeerXML.Models.Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("BeerXML.Models.Water")
                        .WithMany()
                        .HasForeignKey("WaterId");
                });
        }
    }
}
