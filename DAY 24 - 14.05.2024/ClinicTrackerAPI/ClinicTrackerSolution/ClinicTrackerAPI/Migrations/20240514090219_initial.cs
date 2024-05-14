using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicTrackerAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DateOfBirth", "Designation", "Email", "Experience", "Name", "Phone", "Specialization" },
                values: new object[] { 101, new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD", "ramu@gmail.com", 12f, "Ramu", "9876543321", "Heart" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DateOfBirth", "Designation", "Email", "Experience", "Name", "Phone", "Specialization" },
                values: new object[] { 102, new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "MBBS", "somu@gmail.com", 8f, "Somu", "9988776655", "Sugar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
