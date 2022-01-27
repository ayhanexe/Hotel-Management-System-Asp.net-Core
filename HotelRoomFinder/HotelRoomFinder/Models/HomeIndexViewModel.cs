using HotelRoomFinder.Models.Entities;
using System.Collections.Generic;

namespace HotelRoomFinder.Models
{
    public class HomeIndexViewModel
    {
        public CommentAddViewModel commentViewModel { get; set; }
        public User user { get; set; }
        public int id { get; set; }
        public int param { get; set; }
        public Room room { get; set; }
        public string area { get; set; }
        public RoomReserveViewModel reserve { get; set; }
        public RoomFilterViewModel RoomFilter { get; set; }
        public Hotel Hotel { get; set; }
        public List<Hotel> Hotels { get; set; }
        public Header Header { get; set; }
        public Footer Footer { get; set; }
        public Layout Layout { get; set; }
        public List<Room> Rooms { get; set; }
        public List<HeaderItem> HeaderItems { get; set; }
        public List<LayoutFeature> Features { get; set; }
        public List<LayoutBlogItem> BlogItems { get; set; }
        public List<LayoutRoomImageSliderItem> layoutRoomImageSliderItems { get; set; }
        public List<LayoutCounterItem> layoutCounterItems { get; set; }
        public List<LayoutCommentItem> layoutCommentItems { get; set; }
    }
}
