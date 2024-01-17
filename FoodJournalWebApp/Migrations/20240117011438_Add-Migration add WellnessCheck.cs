using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodJournalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationaddWellnessCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WellnessCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhysiologicalFeedbackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellnessCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WellnessCheck_PhysiologicalFeedback_PhysiologicalFeedbackId",
                        column: x => x.PhysiologicalFeedbackId,
                        principalTable: "PhysiologicalFeedback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WellnessCheck_PhysiologicalFeedbackId",
                table: "WellnessCheck",
                column: "PhysiologicalFeedbackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WellnessCheck");
        }
    }
}
