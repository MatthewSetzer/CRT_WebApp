using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRT_WebApp.Server.Data.Migrations
{
    public partial class DbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteState = table.Column<bool>(type: "bit", nullable: false),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuoteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Quotes_QuoteModelId",
                        column: x => x.QuoteModelId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Quotes_QuoteModelId",
                        column: x => x.QuoteModelId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubGroupTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    QuoteModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGroups_Quotes_QuoteModelId",
                        column: x => x.QuoteModelId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    NumberOfUnits = table.Column<double>(type: "float", nullable: false),
                    SubGroupModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssemblyItems_SubGroups_SubGroupModelId",
                        column: x => x.SubGroupModelId,
                        principalTable: "SubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyItems_SubGroupModelId",
                table: "AssemblyItems",
                column: "SubGroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_QuoteModelId",
                table: "Images",
                column: "QuoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_QuoteModelId",
                table: "Notes",
                column: "QuoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_QuoteModelId",
                table: "SubGroups",
                column: "QuoteModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssemblyItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "SubGroups");

            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
