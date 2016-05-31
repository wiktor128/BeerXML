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
            migrationBuilder.DropForeignKey(name: "FK_EquipmentRecipe_Equipment_EquipmentId", table: "EquipmentRecipe");
            migrationBuilder.DropForeignKey(name: "FK_EquipmentRecipe_Recipe_RecipeId", table: "EquipmentRecipe");
            migrationBuilder.DropForeignKey(name: "FK_FermentableRecipe_Fermentable_FermentableId", table: "FermentableRecipe");
            migrationBuilder.DropForeignKey(name: "FK_FermentableRecipe_Recipe_RecipeId", table: "FermentableRecipe");
            migrationBuilder.DropForeignKey(name: "FK_HopRecipe_Hop_HopId", table: "HopRecipe");
            migrationBuilder.DropForeignKey(name: "FK_HopRecipe_Recipe_RecipeId", table: "HopRecipe");
            migrationBuilder.DropForeignKey(name: "FK_MiscRecipe_Misc_MiscId", table: "MiscRecipe");
            migrationBuilder.DropForeignKey(name: "FK_MiscRecipe_Recipe_RecipeId", table: "MiscRecipe");
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Recipe_RecipeId", table: "WaterRecipe");
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Water_WaterId", table: "WaterRecipe");
            migrationBuilder.DropForeignKey(name: "FK_YeastRecipe_Recipe_RecipeId", table: "YeastRecipe");
            migrationBuilder.DropForeignKey(name: "FK_YeastRecipe_Yeast_YeastId", table: "YeastRecipe");
            migrationBuilder.CreateTable(
                name: "Mash",
                columns: table => new
                {
                    MashId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipAdjust = table.Column<bool>(nullable: false),
                    GrainTemp = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Ph = table.Column<float>(nullable: false),
                    SpargeTemp = table.Column<float>(nullable: false),
                    TunTemp = table.Column<float>(nullable: false),
                    TunWeight = table.Column<float>(nullable: false),
                    TunspecificHeat = table.Column<float>(nullable: false),
                    Version = table.Column<int>(nullable: false)
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
                    EndTemp = table.Column<float>(nullable: false),
                    InfuseAmount = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RampTime = table.Column<float>(nullable: false),
                    StepTemp = table.Column<float>(nullable: false),
                    StepTime = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MashStep", x => x.MashStepId);
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
            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRecipe_Equipment_EquipmentId",
                table: "EquipmentRecipe",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRecipe_Recipe_RecipeId",
                table: "EquipmentRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_FermentableRecipe_Fermentable_FermentableId",
                table: "FermentableRecipe",
                column: "FermentableId",
                principalTable: "Fermentable",
                principalColumn: "FermentableId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_FermentableRecipe_Recipe_RecipeId",
                table: "FermentableRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_HopRecipe_Hop_HopId",
                table: "HopRecipe",
                column: "HopId",
                principalTable: "Hop",
                principalColumn: "HopId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_HopRecipe_Recipe_RecipeId",
                table: "HopRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_MiscRecipe_Misc_MiscId",
                table: "MiscRecipe",
                column: "MiscId",
                principalTable: "Misc",
                principalColumn: "MiscId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_MiscRecipe_Recipe_RecipeId",
                table: "MiscRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Recipe_RecipeId",
                table: "WaterRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Water_WaterId",
                table: "WaterRecipe",
                column: "WaterId",
                principalTable: "Water",
                principalColumn: "WaterId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_YeastRecipe_Recipe_RecipeId",
                table: "YeastRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_YeastRecipe_Yeast_YeastId",
                table: "YeastRecipe",
                column: "YeastId",
                principalTable: "Yeast",
                principalColumn: "YeastId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EquipmentRecipe_Equipment_EquipmentId", table: "EquipmentRecipe");
            migrationBuilder.DropForeignKey(name: "FK_EquipmentRecipe_Recipe_RecipeId", table: "EquipmentRecipe");
            migrationBuilder.DropForeignKey(name: "FK_FermentableRecipe_Fermentable_FermentableId", table: "FermentableRecipe");
            migrationBuilder.DropForeignKey(name: "FK_FermentableRecipe_Recipe_RecipeId", table: "FermentableRecipe");
            migrationBuilder.DropForeignKey(name: "FK_HopRecipe_Hop_HopId", table: "HopRecipe");
            migrationBuilder.DropForeignKey(name: "FK_HopRecipe_Recipe_RecipeId", table: "HopRecipe");
            migrationBuilder.DropForeignKey(name: "FK_MiscRecipe_Misc_MiscId", table: "MiscRecipe");
            migrationBuilder.DropForeignKey(name: "FK_MiscRecipe_Recipe_RecipeId", table: "MiscRecipe");
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Recipe_RecipeId", table: "WaterRecipe");
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Water_WaterId", table: "WaterRecipe");
            migrationBuilder.DropForeignKey(name: "FK_YeastRecipe_Recipe_RecipeId", table: "YeastRecipe");
            migrationBuilder.DropForeignKey(name: "FK_YeastRecipe_Yeast_YeastId", table: "YeastRecipe");
            migrationBuilder.DropTable("MashRecipe");
            migrationBuilder.DropTable("MashStepMash");
            migrationBuilder.DropTable("Mash");
            migrationBuilder.DropTable("MashStep");
            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRecipe_Equipment_EquipmentId",
                table: "EquipmentRecipe",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRecipe_Recipe_RecipeId",
                table: "EquipmentRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FermentableRecipe_Fermentable_FermentableId",
                table: "FermentableRecipe",
                column: "FermentableId",
                principalTable: "Fermentable",
                principalColumn: "FermentableId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_FermentableRecipe_Recipe_RecipeId",
                table: "FermentableRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_HopRecipe_Hop_HopId",
                table: "HopRecipe",
                column: "HopId",
                principalTable: "Hop",
                principalColumn: "HopId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_HopRecipe_Recipe_RecipeId",
                table: "HopRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_MiscRecipe_Misc_MiscId",
                table: "MiscRecipe",
                column: "MiscId",
                principalTable: "Misc",
                principalColumn: "MiscId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_MiscRecipe_Recipe_RecipeId",
                table: "MiscRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Recipe_RecipeId",
                table: "WaterRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Water_WaterId",
                table: "WaterRecipe",
                column: "WaterId",
                principalTable: "Water",
                principalColumn: "WaterId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_YeastRecipe_Recipe_RecipeId",
                table: "YeastRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_YeastRecipe_Yeast_YeastId",
                table: "YeastRecipe",
                column: "YeastId",
                principalTable: "Yeast",
                principalColumn: "YeastId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
