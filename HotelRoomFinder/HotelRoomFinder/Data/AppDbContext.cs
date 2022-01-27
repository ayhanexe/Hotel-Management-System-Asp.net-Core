using HotelRoomFinder.Areas.Admin.Model.Entities;
using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomFinder.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Footer> Footer { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<HeaderItem> HeaderItems { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomPhoto> RoomPhotos { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<RoomComment> RoomComments { get; set; }

        public DbSet<Layout> Layout { get; set; }
        public DbSet<LayoutFeature> LayoutFeatures { get; set; }
        public DbSet<LayoutBlogItem> LayoutBlogItems { get; set; }
        public DbSet<LayoutRoomImageSliderItem> LayoutRoomImageSliderItems { get; set; }
        public DbSet<LayoutRoomSliderItem> LayoutRoomSliderItems { get; set; }
        public DbSet<LayoutCounterItem> LayoutCounterItems { get; set; }
        public DbSet<LayoutCommentItem> LayoutCommentItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // Area => Admin
        public DbSet<Category> AdminCategories { get; set; }
        public DbSet<DropdownItem> AdminDropdownItems { get; set; }
    }
}
