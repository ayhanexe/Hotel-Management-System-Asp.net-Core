using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class addHotelSliderFieldsToLayoutModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelSliderDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotelSliderPhoto",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotelSliderTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelSliderDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "HotelSliderPhoto",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "HotelSliderTitle",
                table: "Layout");
        }
    }
}
