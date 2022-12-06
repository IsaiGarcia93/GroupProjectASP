using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProjectASP.Migrations
{
    public partial class UpdateOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartString",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditCardNumber",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpirationDate",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartString",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Orders");
        }
    }
}
