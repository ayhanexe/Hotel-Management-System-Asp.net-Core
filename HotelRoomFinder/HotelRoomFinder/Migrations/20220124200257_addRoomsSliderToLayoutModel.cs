using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class addRoomsSliderToLayoutModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomsSliderDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomsSliderPhoto",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomsSliderTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomsSliderDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "RoomsSliderPhoto",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "RoomsSliderTitle",
                table: "Layout");
        }
    }
}
