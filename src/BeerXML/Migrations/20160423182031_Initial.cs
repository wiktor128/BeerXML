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
                name: "Recipe",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false)
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
                    TasteNotes = table.Column<string>(nullable: true),
                    TasteRating = table.Column<float>(nullable: false),
                    TertiaryAge = table.Column<int>(nullable: false),
                    TertiaryTemp = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeID);
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
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterRecipe_Water_WaterId",
                        column: x => x.WaterId,
                        principalTable: "Water",
                        principalColumn: "WaterId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("WaterRecipe");
            migrationBuilder.DropTable("Recipe");
            migrationBuilder.DropTable("Water");
        }
    }
}
