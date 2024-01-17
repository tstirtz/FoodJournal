using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodJournalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Meal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DailyWellnessCheckId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_WellnessCheck_DailyWellnessCheckId",
                        column: x => x.DailyWellnessCheckId,
                        principalTable: "WellnessCheck",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_DayId",
                table: "Meal",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_DailyWellnessCheckId",
                table: "Day",
                column: "DailyWellnessCheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Day_DayId",
                table: "Meal");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropIndex(
                name: "IX_Meal_DayId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Meal");
        }
    }
}
