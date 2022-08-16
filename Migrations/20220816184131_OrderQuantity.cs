using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCuisine.Migrations
{
    public partial class OrderQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderItemsPrice",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderItemsQuantity",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderItemsPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderItemsQuantity",
                table: "Order");
        }
    }
}
