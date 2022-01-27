using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class addAboutFieldsToLayoutModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AboutBaseSliderDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutBaseSliderTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutCEOName",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutCEOPhoto",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutCEOText",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutFeatureDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutFeatureTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutStaffDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutStaffTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutVideoDescription",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutVideoPhoto",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutVideoTitle",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutVideoUrl",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayoutId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Layout_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_LayoutId",
                table: "Staff",
                column: "LayoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropColumn(
                name: "AboutBaseSliderDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutBaseSliderTitle",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutCEOName",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutCEOPhoto",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutCEOText",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutFeatureDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutFeatureTitle",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutStaffDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutStaffTitle",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutVideoDescription",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutVideoPhoto",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutVideoTitle",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AboutVideoUrl",
                table: "Layout");

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
    }
}
