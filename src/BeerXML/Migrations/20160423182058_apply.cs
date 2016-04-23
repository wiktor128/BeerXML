using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace BeerXML.Migrations
{
    public partial class apply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Recipe_RecipeId", table: "WaterRecipe");
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Water_WaterId", table: "WaterRecipe");
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Recipe_RecipeId",
                table: "WaterRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Water_WaterId",
                table: "WaterRecipe",
                column: "WaterId",
                principalTable: "Water",
                principalColumn: "WaterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Recipe_RecipeId", table: "WaterRecipe");
            migrationBuilder.DropForeignKey(name: "FK_WaterRecipe_Water_WaterId", table: "WaterRecipe");
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Recipe_RecipeId",
                table: "WaterRecipe",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_WaterRecipe_Water_WaterId",
                table: "WaterRecipe",
                column: "WaterId",
                principalTable: "Water",
                principalColumn: "WaterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
