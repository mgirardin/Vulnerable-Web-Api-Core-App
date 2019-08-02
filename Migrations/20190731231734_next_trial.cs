using Microsoft.EntityFrameworkCore.Migrations;

namespace APITest.Migrations
{
    public partial class next_trial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_APIItems",
                table: "APIItems");

            migrationBuilder.RenameTable(
                name: "APIItems",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "APIItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APIItems",
                table: "APIItems",
                column: "Id");
        }
    }
}
