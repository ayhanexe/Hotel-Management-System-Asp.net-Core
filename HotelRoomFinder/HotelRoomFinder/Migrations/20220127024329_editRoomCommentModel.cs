using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class editRoomCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RoomComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RoomComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "RoomComments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RoomComments");
        }
    }
}
