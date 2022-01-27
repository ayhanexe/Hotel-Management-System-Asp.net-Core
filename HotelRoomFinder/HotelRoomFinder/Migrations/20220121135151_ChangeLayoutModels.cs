using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomFinder.Migrations
{
    public partial class ChangeLayoutModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CounterItems");

            migrationBuilder.DropTable(
                name: "HeaderItems");

            migrationBuilder.DropTable(
                name: "RoomSliderSectionItems");

            migrationBuilder.DropTable(
                name: "SimpleRoomSliderItems");

            migrationBuilder.DropTable(
                name: "TestimonialItems");

            migrationBuilder.DropTable(
                name: "HomeLayout");

            migrationBuilder.CreateTable(
                name: "Layout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSliderDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSliderImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomImageSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomImageSliderDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomSliderDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentSliderDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutBlogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutBlogItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutCommentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutCommentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LayoutCommentItems_RoomComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "RoomComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LayoutCounterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutCounterItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutRoomImageSliderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutRoomImageSliderItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutRoomSliderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutRoomSliderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LayoutRoomSliderItems_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LayoutFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    LayoutId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LayoutFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutFeatures_Layout_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutCommentItems_CommentId",
                table: "LayoutCommentItems",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFeatures_FeatureId",
                table: "LayoutFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutFeatures_LayoutId",
                table: "LayoutFeatures",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutRoomSliderItems_RoomId",
                table: "LayoutRoomSliderItems",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutBlogItems");

            migrationBuilder.DropTable(
                name: "LayoutCommentItems");

            migrationBuilder.DropTable(
                name: "LayoutCounterItems");

            migrationBuilder.DropTable(
                name: "LayoutFeatures");

            migrationBuilder.DropTable(
                name: "LayoutRoomImageSliderItems");

            migrationBuilder.DropTable(
                name: "LayoutRoomSliderItems");

            migrationBuilder.DropTable(
                name: "Layout");

            migrationBuilder.CreateTable(
                name: "HeaderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeLayout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutCardButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutCardButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutCardImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutCardText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutCardTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeaturesIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeaturesText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSliderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSliderImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsSectionButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsSectionButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsSectionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SimpleRoomSliderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SimpleRoomSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestimonialsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestimonialsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeLayout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CounterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeLayoutId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterItems_HomeLayout_HomeLayoutId",
                        column: x => x.HomeLayoutId,
                        principalTable: "HomeLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomSliderSectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeLayoutId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSliderSectionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomSliderSectionItems_HomeLayout_HomeLayoutId",
                        column: x => x.HomeLayoutId,
                        principalTable: "HomeLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SimpleRoomSliderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeLayoutId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleRoomSliderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimpleRoomSliderItems_HomeLayout_HomeLayoutId",
                        column: x => x.HomeLayoutId,
                        principalTable: "HomeLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestimonialItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeLayoutId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestimonialItems_HomeLayout_HomeLayoutId",
                        column: x => x.HomeLayoutId,
                        principalTable: "HomeLayout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CounterItems_HomeLayoutId",
                table: "CounterItems",
                column: "HomeLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSliderSectionItems_HomeLayoutId",
                table: "RoomSliderSectionItems",
                column: "HomeLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleRoomSliderItems_HomeLayoutId",
                table: "SimpleRoomSliderItems",
                column: "HomeLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_TestimonialItems_HomeLayoutId",
                table: "TestimonialItems",
                column: "HomeLayoutId");
        }
    }
}
