using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackShop.Migrations
{
    public partial class AddTreatDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TreatDescription",
                table: "Treats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatDescription",
                table: "Treats");
        }
    }
}
