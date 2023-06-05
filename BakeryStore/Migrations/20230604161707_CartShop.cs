using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryStore.Migrations
{
    /// <inheritdoc />
    public partial class CartShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Order_OrderId",
                table: "ShopCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShopCartItem_OrderId",
                table: "ShopCartItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Order",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                columns: new[] { "ShopCartId", "ProductId" });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId1 = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId1",
                table: "OrderDetails",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "ShopCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_OrderId",
                table: "ShopCartItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Order_OrderId",
                table: "ShopCartItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
