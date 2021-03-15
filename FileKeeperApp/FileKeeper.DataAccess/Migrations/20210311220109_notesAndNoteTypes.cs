using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileKeeper.DataAccess.Migrations
{
    public partial class notesAndNoteTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportantDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NoteTypes",
                columns: new[] { "Id", "NoteTypeName" },
                values: new object[] { 1, "Important" });

            migrationBuilder.InsertData(
                table: "NoteTypes",
                columns: new[] { "Id", "NoteTypeName" },
                values: new object[] { 2, "ToDo" });

            migrationBuilder.InsertData(
                table: "NoteTypes",
                columns: new[] { "Id", "NoteTypeName" },
                values: new object[] { 3, "Check" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NoteTypes");
        }
    }
}
