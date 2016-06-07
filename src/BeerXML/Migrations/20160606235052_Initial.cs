using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace BeerXML.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatchSize = table.Column<double>(nullable: false),
                    BoilSize = table.Column<double>(nullable: false),
                    BoilTime = table.Column<double>(nullable: false),
                    CalcBoilVolume = table.Column<bool>(nullable: false),
                    EvapRate = table.Column<double>(nullable: false),
                    HopUtilization = table.Column<double>(nullable: false),
                    LauterDeadspace = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TopUpKettle = table.Column<double>(nullable: false),
                    TopUpWater = table.Column<double>(nullable: false),
                    TrubChillerLoss = table.Column<double>(nullable: false),
                    TunSpecificHeat = table.Column<double>(nullable: false),
                    TunVolume = table.Column<double>(nullable: false),
                    TunWeight = table.Column<double>(nullable: false),
                    Version = table.Column<double>(nullable: false)
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
                    Amount = table.Column<double>(nullable: false),
                    CoarseFineDiff = table.Column<double>(nullable: false),
                    Color = table.Column<double>(nullable: false),
                    DiastaticPower = table.Column<double>(nullable: false),
                    IbuGalPerLb = table.Column<double>(nullable: false),
                    MaxInBatch = table.Column<double>(nullable: false),
                    Moisture = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Protein = table.Column<double>(nullable: false),
                    RecommendedMash = table.Column<double>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<double>(nullable: false),
                    Yeld = table.Column<double>(nullable: false)
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
                    Alpha = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Beta = table.Column<double>(nullable: false),
                    Caryophyllene = table.Column<double>(nullable: false),
                    Cohumulone = table.Column<double>(nullable: false),
                    Form = table.Column<string>(nullable: true),
                    HSI = table.Column<double>(nullable: false),
                    Humulene = table.Column<double>(nullable: false),
                    Myrcene = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Substitutes = table.Column<string>(nullable: true),
                    Time = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Use = table.Column<string>(nullable: false),
                    Version = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hop", x => x.HopId);
                });
            migrationBuilder.CreateTable(
                name: "Mash",
                columns: table => new
                {
                    MashId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipAdjust = table.Column<bool>(nullable: false),
                    GrainTemp = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Ph = table.Column<double>(nullable: false),
                    SpargeTemp = table.Column<double>(nullable: false),
                    TunTemp = table.Column<double>(nullable: false),
                    TunWeight = table.Column<double>(nullable: false),
                    TunspecificHeat = table.Column<double>(nullable: false),
                    Version = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mash", x => x.MashId);
                });
            migrationBuilder.CreateTable(
                name: "MashStep",
                columns: table => new
                {
                    MashStepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndTemp = table.Column<double>(nullable: false),
                    InfuseAmount = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RampTime = table.Column<double>(nullable: false),
                    StepTemp = table.Column<double>(nullable: false),
                    StepTime = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MashStep", x => x.MashStepId);
                });
            migrationBuilder.CreateTable(
                name: "Misc",
                columns: table => new
                {
                    MiscId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    AmountIsWeight = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Time = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Use = table.Column<string>(nullable: false),
                    UseFor = table.Column<string>(nullable: true),
                    Version = table.Column<double>(nullable: false)
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
                    AbvMax = table.Column<double>(nullable: false),
                    AbvMin = table.Column<double>(nullable: false),
                    CarbMax = table.Column<double>(nullable: false),
                    CarbMin = table.Column<double>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    CategoryNumber = table.Column<string>(nullable: false),
                    ColorMax = table.Column<double>(nullable: false),
                    ColorMin = table.Column<double>(nullable: false),
                    Examples = table.Column<string>(nullable: true),
                    FgMax = table.Column<double>(nullable: false),
                    FgMin = table.Column<double>(nullable: false),
                    IbuMax = table.Column<double>(nullable: false),
                    IbuMin = table.Column<double>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    OgMax = table.Column<double>(nullable: false),
                    OgMin = table.Column<double>(nullable: false),
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
                    Amount = table.Column<double>(nullable: false),
                    Bicarbonate = table.Column<double>(nullable: false),
                    Calcium = table.Column<double>(nullable: false),
                    Chloride = table.Column<double>(nullable: false),
                    Magnesium = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Ph = table.Column<double>(nullable: false),
                    Sodium = table.Column<double>(nullable: false),
                    Sulfate = table.Column<double>(nullable: false),
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
                name: "MashStepMash",
                columns: table => new
                {
                    MashId = table.Column<int>(nullable: false),
                    MashStepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MashStepMash", x => new { x.MashId, x.MashStepId });
                    table.ForeignKey(
                        name: "FK_MashStepMash_Mash_MashId",
                        column: x => x.MashId,
                        principalTable: "Mash",
                        principalColumn: "MashId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MashStepMash_MashStep_MashStepId",
                        column: x => x.MashStepId,
                        principalTable: "MashStep",
                        principalColumn: "MashStepId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<double>(nullable: false),
                    AgeTemp = table.Column<double>(nullable: false),
                    AsstBrewer = table.Column<string>(nullable: true),
                    BatchSize = table.Column<double>(nullable: false),
                    BoilSize = table.Column<double>(nullable: false),
                    BoilTime = table.Column<double>(nullable: false),
                    Brewer = table.Column<string>(nullable: false),
                    Carbonation = table.Column<double>(nullable: false),
                    CarbonationTemp = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Efficiency = table.Column<double>(nullable: false),
                    FG = table.Column<double>(nullable: false),
                    FermentationStages = table.Column<double>(nullable: false),
                    ForcedCarbonation = table.Column<bool>(nullable: false),
                    KegPrimingFactor = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    OG = table.Column<double>(nullable: false),
                    PrimaryAges = table.Column<double>(nullable: false),
                    PrimaryTemp = table.Column<double>(nullable: false),
                    PrimingSugarEquiv = table.Column<double>(nullable: false),
                    PrimingSugarName = table.Column<string>(nullable: true),
                    SecondaryAge = table.Column<double>(nullable: false),
                    SecondaryTemp = table.Column<double>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    TasteNotes = table.Column<string>(nullable: true),
                    TasteRating = table.Column<double>(nullable: false),
                    TertiaryAge = table.Column<double>(nullable: false),
                    TertiaryTemp = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "MashRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    MashId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MashRecipe", x => new { x.RecipeId, x.MashId });
                    table.ForeignKey(
                        name: "FK_MashRecipe_Mash_MashId",
                        column: x => x.MashId,
                        principalTable: "Mash",
                        principalColumn: "MashId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MashRecipe_Recipe_RecipeId",
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
            migrationBuilder.DropTable("MashRecipe");
            migrationBuilder.DropTable("MashStepMash");
            migrationBuilder.DropTable("MiscRecipe");
            migrationBuilder.DropTable("WaterRecipe");
            migrationBuilder.DropTable("YeastRecipe");
            migrationBuilder.DropTable("Equipment");
            migrationBuilder.DropTable("Fermentable");
            migrationBuilder.DropTable("Hop");
            migrationBuilder.DropTable("Mash");
            migrationBuilder.DropTable("MashStep");
            migrationBuilder.DropTable("Misc");
            migrationBuilder.DropTable("Water");
            migrationBuilder.DropTable("Recipe");
            migrationBuilder.DropTable("Yeast");
            migrationBuilder.DropTable("Style");
        }
    }
}
