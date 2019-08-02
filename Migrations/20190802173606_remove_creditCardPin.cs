using Microsoft.EntityFrameworkCore.Migrations;

namespace APITest.Migrations
{
    public partial class remove_creditCardPin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardPIN",
                table: "CreditCards");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CreditCardPIN",
                table: "CreditCards",
                nullable: false,
                defaultValue: 0);
        }
    }
}
