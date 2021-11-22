using Microsoft.EntityFrameworkCore.Migrations;

namespace CRT_WebApp.Server.Data.Migrations
{
    public partial class AssemblyItemModel_MetricField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Metric",
                table: "AssemblyItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metric",
                table: "AssemblyItems");
        }
    }
}
