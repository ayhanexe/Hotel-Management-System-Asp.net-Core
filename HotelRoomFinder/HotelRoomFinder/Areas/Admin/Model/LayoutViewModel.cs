using HotelRoomFinder.Models.Entities;
using System.Collections.Generic;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class LayoutViewModel
    {
        public List<LayoutFeature> LayoutFeatures { get; set; }
        public List<Feature> Features { get; set; }
        public Layout MainLayout { get; set; }
        public Header BaseHeader { get; set; }
        public HeaderViewModel Header { get; set; }
        public Footer Footer { get; set; }
        public HeaderItem HeaderItem { get; set; }
        public LayoutBlogItemViewModel LayoutBlogItem { get; set; }
        public List<HeaderItem> HeaderItems { get; set; }

        public MainLayoutViewModel Layout { get; set; }
        public List<LayoutRoomImageSliderItem> RoomImageSliderItems { get; set; }
        public List<LayoutCommentItem> LayoutCommentItems { get; set; }
        public List<LayoutBlogItem> LayoutBlogItems { get; set; }
    }
}
