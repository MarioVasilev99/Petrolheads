using Microsoft.EntityFrameworkCore.Migrations;

namespace Petrolheads.Data.Migrations
{
    public partial class CarMainImageUrlMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Cars");
        }
    }
}
