using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal_Blog_Api.Migrations
{
    public partial class editCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aythor",
                table: "Articles",
                newName: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Articles",
                newName: "Aythor");
        }
    }
}
