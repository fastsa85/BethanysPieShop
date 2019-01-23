using Microsoft.EntityFrameworkCore.Migrations;

namespace BethanysPieShop.Migrations
{
    public partial class FixShopingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShopingCartItems",
                newName: "ShopingCartId");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartItemId",
                table: "ShopingCartItems",
                newName: "ShopingCartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopingCartId",
                table: "ShopingCartItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "ShopingCartItemId",
                table: "ShopingCartItems",
                newName: "ShoppingCartItemId");
        }
    }
}
