using Microsoft.EntityFrameworkCore.Migrations;

namespace Petrolheads.Data.Migrations
{
    public partial class CarPhotoIsMainImageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainImage",
                table: "CarPhotos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainImage",
                table: "CarPhotos");
        }
    }
}
