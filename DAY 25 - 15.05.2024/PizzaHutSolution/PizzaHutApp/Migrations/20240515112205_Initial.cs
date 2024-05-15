using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHutApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiameterInches = table.Column<int>(type: "int", nullable: false),
                    IsVeg = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 101, "Tamilnadu", new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ramu@gmail,com", "Ramu", "9876543321" },
                    { 102, "Tamilnadu", new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "somu@gmail.com", "Somu", "9988776655" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "DiameterInches", "IsAvailable", "IsVeg", "Name", "Price" },
                values: new object[,]
                {
                    { 110, 5, true, false, "Pizza1", 300m },
                    { 120, 5, true, false, "Pizza2", 400m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
