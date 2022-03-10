using Microsoft.EntityFrameworkCore.Migrations;

namespace orderMicroservice.Migrations
{
    public partial class oinitil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cardNumber",
                table: "Checkout",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cvc",
                table: "Checkout",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "month",
                table: "Checkout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "value",
                table: "Checkout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Checkout",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cardNumber",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "cvc",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "month",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "value",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "year",
                table: "Checkout");
        }
    }
}
