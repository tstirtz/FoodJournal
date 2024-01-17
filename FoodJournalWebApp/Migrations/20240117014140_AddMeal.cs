using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodJournalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WellnessCheckId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_WellnessCheck_WellnessCheckId",
                        column: x => x.WellnessCheckId,
                        principalTable: "WellnessCheck",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MealId",
                table: "Ingredient",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_WellnessCheckId",
                table: "Meal",
                column: "WellnessCheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Meal_MealId",
                table: "Ingredient",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Meal_MealId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_MealId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Ingredient");
        }
    }
}
