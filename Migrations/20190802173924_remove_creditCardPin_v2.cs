using Microsoft.EntityFrameworkCore.Migrations;

namespace APITest.Migrations
{
    public partial class remove_creditCardPin_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecurityNumber",
                table: "CreditCards",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SecurityNumber",
                table: "CreditCards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
