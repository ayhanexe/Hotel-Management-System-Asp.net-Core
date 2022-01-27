using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class addFeatureIdToRoomFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatures_Features_FeatureId",
                table: "RoomFeatures");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureId",
                table: "RoomFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatures_Features_FeatureId",
                table: "RoomFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatures_Features_FeatureId",
                table: "RoomFeatures");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureId",
                table: "RoomFeatures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatures_Features_FeatureId",
                table: "RoomFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
