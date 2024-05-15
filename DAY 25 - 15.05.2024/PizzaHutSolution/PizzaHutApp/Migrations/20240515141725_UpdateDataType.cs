using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHutApp.Migrations
{
    public partial class UpdateDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Pizzas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 110,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 120,
                column: "Price",
                value: 400);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 110,
                column: "Price",
                value: 300m);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 120,
                column: "Price",
                value: 400m);
        }
    }
}
