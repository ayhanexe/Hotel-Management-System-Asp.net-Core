using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class UpdateCategoryAndDropdownItemForAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "AdminCategories");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "AdminDropdownItems",
                newName: "Controller");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "AdminDropdownItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "AdminCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "AdminCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "AdminDropdownItems");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "AdminCategories");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "AdminCategories");

            migrationBuilder.RenameColumn(
                name: "Controller",
                table: "AdminDropdownItems",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "AdminCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
