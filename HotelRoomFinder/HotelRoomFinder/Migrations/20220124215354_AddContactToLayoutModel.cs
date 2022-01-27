using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class AddContactToLayoutModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactSliderDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactSliderPhoto",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactSliderTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactSliderDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "ContactSliderPhoto",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "ContactSliderTitle",
                table: "Layout");
        }
    }
}
