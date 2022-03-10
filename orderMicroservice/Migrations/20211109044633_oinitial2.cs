using Microsoft.EntityFrameworkCore.Migrations;

namespace orderMicroservice.Migrations
{
    public partial class oinitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "Checkout");

            migrationBuilder.AlterColumn<int>(
                name: "totalPrice",
                table: "Checkout",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "totalPrice",
                table: "Checkout",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "value",
                table: "Checkout",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
