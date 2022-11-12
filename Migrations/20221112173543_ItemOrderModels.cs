using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProjectASP.Migrations
{
    public partial class ItemOrderModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImageUpload = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetail",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetail", x => new { x.OrderID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_OrdersDetail_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDetail_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "DateOfCreation", "Description", "ImageUpload", "Price", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1950, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beautiful Art Work", "~/wwwroot/lib/Images/Art1.jpg", 5000.0, "The Scream" },
                    { 2, new DateTime(1650, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing Art Work", "~/wwwroot/lib/Images/Art2.jpg", 15000.0, "The Woman on the Wall" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "OrderDate", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000.0 },
                    { 2, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "OrdersDetail",
                columns: new[] { "OrderID", "ItemID", "Amount", "Quantity" },
                values: new object[] { 1, 2, 15000.0, 1 });

            migrationBuilder.InsertData(
                table: "OrdersDetail",
                columns: new[] { "OrderID", "ItemID", "Amount", "Quantity" },
                values: new object[] { 2, 1, 5000.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetail_ItemID",
                table: "OrdersDetail",
                column: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersDetail");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
