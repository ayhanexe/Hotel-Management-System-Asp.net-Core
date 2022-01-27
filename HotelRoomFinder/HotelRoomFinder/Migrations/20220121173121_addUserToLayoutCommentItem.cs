using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class addUserToLayoutCommentItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LayoutCommentItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutCommentItems_UserId",
                table: "LayoutCommentItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutCommentItems_AspNetUsers_UserId",
                table: "LayoutCommentItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutCommentItems_AspNetUsers_UserId",
                table: "LayoutCommentItems");

            migrationBuilder.DropIndex(
                name: "IX_LayoutCommentItems_UserId",
                table: "LayoutCommentItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LayoutCommentItems");
        }
    }
}
