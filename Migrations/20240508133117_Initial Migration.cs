using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoahStener_KodprovLIA.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "CarIssues",
                columns: table => new
                {
                    CarIssueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IssueReported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarIssues", x => x.CarIssueID);
                    table.ForeignKey(
                        name: "FK_CarIssues_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarID", "Model", "RegNumber" },
                values: new object[,]
                {
                    { 1, "Volvo", "ABC543" },
                    { 2, "Saab", "BBB123" },
                    { 3, "Kia", "CCC741" },
                    { 4, "Volvo", "DAB092" }
                });

            migrationBuilder.InsertData(
                table: "CarIssues",
                columns: new[] { "CarIssueID", "CarID", "Description", "IssueReported" },
                values: new object[,]
                {
                    { 200, 1, "Motorfel", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 201, 3, "Fel med växellåda", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 202, 2, "Punktering", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 203, 1, "Elektronik problem", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarIssues_CarID",
                table: "CarIssues",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RegNumber",
                table: "Cars",
                column: "RegNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarIssues");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
