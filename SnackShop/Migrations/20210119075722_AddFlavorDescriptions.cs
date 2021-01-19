using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackShop.Migrations
{
    public partial class AddFlavorDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlavorDescription",
                table: "Flavors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlavorDescription",
                table: "Flavors");
        }
    }
}
