using Microsoft.EntityFrameworkCore.Migrations;

namespace FileKeeper.DataAccess.Migrations
{
    public partial class noteModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
