using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationSystem.Migrations
{
    public partial class CreateTableDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccinationStation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Batch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinationStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccine_VaccinationStation_VaccinationStationId",
                        column: x => x.VaccinationStationId,
                        principalTable: "VaccinationStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationStation_Name",
                table: "VaccinationStation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_Batch",
                table: "Vaccine",
                column: "Batch",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_VaccinationStationId",
                table: "Vaccine",
                column: "VaccinationStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "VaccinationStation");
        }
    }
}
