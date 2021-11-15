using Microsoft.EntityFrameworkCore.Migrations;

namespace CRT_WebApp.Server.Data.Migrations
{
    public partial class AssemblyItemModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "AssemblyItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "AssemblyItems");
        }
    }
}
