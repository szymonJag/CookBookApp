using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBookApp.DataAccess.Migrations
{
    public partial class authorOfProductAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeAuthor",
                table: "Recipes",
                newName: "Author");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Recipes",
                newName: "RecipeAuthor");
        }
    }
}
