using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace BeerXML.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatchSize = table.Column<float>(nullable: false),
                    BoilSize = table.Column<float>(nullable: false),
                    BoilTime = table.Column<float>(nullable: false),
                    CalcBoilVolume = table.Column<bool>(nullable: false),
                    EvapRate = table.Column<float>(nullable: false),
                    HopUtilization = table.Column<float>(nullable: false),
                    LauterDeadspace = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TopUpKettle = table.Column<float>(nullable: false),
                    TopUpWater = table.Column<float>(nullable: false),
                    TrubChillerLoss = table.Column<float>(nullable: false),
                    TunSpecificHeat = table.Column<float>(nullable: false),
                    TunVolume = table.Column<float>(nullable: false),
                    TunWeight = table.Column<float>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                });
            migrationBuilder.CreateTable(
                name: "Fermentable",
                columns: table => new
                {
                    FermentableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddAfterBoil = table.Column<bool>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    CoarseFineDiff = table.Column<float>(nullable: false),
                    Color = table.Column<float>(nullable: false),
                    DiastaticPower = table.Column<float>(nullable: false),
                    IbuGalPerLb = table.Column<float>(nullable: false),
                    MaxInBatch = table.Column<float>(nullable: false),
                    Moisture = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Protein = table.Column<float>(nullable: false),
                    RecommendedMash = table.Column<float>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Yeld = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentable", x => x.FermentableId);
                });
            migrationBuilder.CreateTable(
                name: "Hop",
                columns: table => new
                {
                    HopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alpha = table.Column<float>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Beta = table.Column<float>(nullable: false),
                    Caryophyllene = table.Column<float>(nullable: false),
                    Cohumulone = table.Column<float>(nullable: false),
                    Form = table.Column<string>(nullable: true),
                    HSI = table.Column<float>(nullable: false),
                    Humulene = table.Column<float>(nullable: false),
                    Myrcene = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Substitutes = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Use = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hop", x => x.HopId);
                });
            migrationBuilder.CreateTable(
                name: "Misc",
                columns: table => new
                {
                    MiscId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    AmountIsWeight = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Use = table.Column<string>(nullable: false),
                    UseFor = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Misc", x => x.MiscId);
                });
            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    StyleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbvMax = table.Column<float>(nullable: false),
                    AbvMin = table.Column<float>(nullable: false),
                    CarbMax = table.Column<float>(nullable: false),
                    CarbMin = table.Column<float>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    CategoryNumber = table.Column<string>(nullable: false),
                    ColorMax = table.Column<float>(nullable: false),
                    ColorMin = table.Column<float>(nullable: false),
                    Examples = table.Column<string>(nullable: true),
                    FgMax = table.Column<float>(nullable: false),
                    FgMin = table.Column<float>(nullable: false),
                    IbuMax = table.Column<float>(nullable: false),
                    IbuMin = table.Column<float>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    OgMax = table.Column<float>(nullable: false),
                    OgMin = table.Column<float>(nullable: false),
                    Profile = table.Column<string>(nullable: true),
                    StyleGuide = table.Column<string>(nullable: false),
                    StyleLetter = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.StyleId);
                });
            migrationBuilder.CreateTable(
                name: "Water",
                columns: table => new
                {
                    WaterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    Bicarbonate = table.Column<float>(nullable: false),
                    Calcium = table.Column<float>(nullable: false),
                    Chloride = table.Column<float>(nullable: false),
                    Magnesium = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Ph = table.Column<float>(nullable: false),
                    Sodium = table.Column<float>(nullable: false),
                    Sulfate = table.Column<float>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water", x => x.WaterId);
                });
            migrationBuilder.CreateTable(
                name: "Yeast",
                columns: table => new
                {
                    YeastId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddToSecondary = table.Column<bool>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    AmountIsWeight = table.Column<bool>(nullable: false),
                    Attenuation = table.Column<float>(nullable: false),
                    BestFor = table.Column<string>(nullable: true),
                    Flocculation = table.Column<string>(nullable: true),
                    Form = table.Column<string>(nullable: false),
                    Laboratory = table.Column<string>(nullable: true),
                    MaxReuse = table.Column<int>(nullable: false),
                    MaxTemperature = table.Column<float>(nullable: false),
                    MinTemperature = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ProductID = table.Column<string>(nullable: true),
                    TimesCultured = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeast", x => x.YeastId);
                });
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    AgeTemp = table.Column<float>(nullable: false),
                    AsstBrewer = table.Column<string>(nullable: true),
                    BatchSize = table.Column<float>(nullable: false),
                    BoilSize = table.Column<float>(nullable: false),
                    BoilTime = table.Column<int>(nullable: false),
                    Brewer = table.Column<string>(nullable: false),
                    Carbonation = table.Column<float>(nullable: false),
                    CarbonationTemp = table.Column<float>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Efficiency = table.Column<float>(nullable: false),
                    FG = table.Column<double>(nullable: false),
                    FermentationStages = table.Column<int>(nullable: false),
                    ForcedCarbonation = table.Column<bool>(nullable: false),
                    KegPrimingFactor = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    OG = table.Column<double>(nullable: false),
                    PrimaryAges = table.Column<int>(nullable: false),
                    PrimaryTemp = table.Column<float>(nullable: false),
                    PrimingSugarEquiv = table.Column<float>(nullable: false),
                    PrimingSugarName = table.Column<string>(nullable: true),
                    SecondaryAge = table.Column<int>(nullable: false),
                    SecondaryTemp = table.Column<float>(nullable: false),
                    StyleStyleId = table.Column<int>(nullable: true),
                    TasteNotes = table.Column<string>(nullable: true),
                    TasteRating = table.Column<float>(nullable: false),
                    TertiaryAge = table.Column<int>(nullable: false),
                    TertiaryTemp = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_Style_StyleStyleId",
                        column: x => x.StyleStyleId,
                        principalTable: "Style",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "EquipmentRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRecipe", x => new { x.RecipeId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_EquipmentRecipe_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "FermentableRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    FermentableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FermentableRecipe", x => new { x.RecipeId, x.FermentableId });
                    table.ForeignKey(
                        name: "FK_FermentableRecipe_Fermentable_FermentableId",
                        column: x => x.FermentableId,
                        principalTable: "Fermentable",
                        principalColumn: "FermentableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FermentableRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "HopRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    HopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopRecipe", x => new { x.RecipeId, x.HopId });
                    table.ForeignKey(
                        name: "FK_HopRecipe_Hop_HopId",
                        column: x => x.HopId,
                        principalTable: "Hop",
                        principalColumn: "HopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MiscRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    MiscId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscRecipe", x => new { x.RecipeId, x.MiscId });
                    table.ForeignKey(
                        name: "FK_MiscRecipe_Misc_MiscId",
                        column: x => x.MiscId,
                        principalTable: "Misc",
                        principalColumn: "MiscId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiscRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "WaterRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    WaterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterRecipe", x => new { x.RecipeId, x.WaterId });
                    table.ForeignKey(
                        name: "FK_WaterRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterRecipe_Water_WaterId",
                        column: x => x.WaterId,
                        principalTable: "Water",
                        principalColumn: "WaterId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "YeastRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    YeastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeastRecipe", x => new { x.RecipeId, x.YeastId });
                    table.ForeignKey(
                        name: "FK_YeastRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YeastRecipe_Yeast_YeastId",
                        column: x => x.YeastId,
                        principalTable: "Yeast",
                        principalColumn: "YeastId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("EquipmentRecipe");
            migrationBuilder.DropTable("FermentableRecipe");
            migrationBuilder.DropTable("HopRecipe");
            migrationBuilder.DropTable("MiscRecipe");
            migrationBuilder.DropTable("WaterRecipe");
            migrationBuilder.DropTable("YeastRecipe");
            migrationBuilder.DropTable("Equipment");
            migrationBuilder.DropTable("Fermentable");
            migrationBuilder.DropTable("Hop");
            migrationBuilder.DropTable("Misc");
            migrationBuilder.DropTable("Water");
            migrationBuilder.DropTable("Recipe");
            migrationBuilder.DropTable("Yeast");
            migrationBuilder.DropTable("Style");
        }
    }
}
