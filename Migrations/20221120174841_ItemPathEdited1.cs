using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProjectASP.Migrations
{
    public partial class ItemPathEdited1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "ImageUpload",
                value: "Art1.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "ImageUpload",
                value: "Art2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "ImageUpload",
                value: "~/Art1.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "ImageUpload",
                value: "~/Art2.jpg");
        }
    }
}
