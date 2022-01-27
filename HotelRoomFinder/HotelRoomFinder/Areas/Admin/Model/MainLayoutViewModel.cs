using HotelRoomFinder.Models;
using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class MainLayoutViewModel
    {
        public string MainSliderTitle { get; set; }

        public string MainSliderDesc { get; set; }

        public IFormFile MainSliderImage { get; set; }
        public string RoomImageSliderTitle { get; set; }
        public string RoomImageSliderDesc { get; set; }
        public string RoomSliderTitle { get; set; }
        public string RoomSliderDesc { get; set; }
        public string CommentSliderTitle { get; set; }
        public string CommentSliderDesc { get; set; }
        public AboutViewModel AboutSection { get; set; }
        public MainSliderViewModel HotelsMainSlider { get; set; }
        public MainSliderViewModel RoomsMainSlider { get; set; }
        public MainSliderViewModel ServicesMainSlider { get; set; }
        public MainSliderViewModel ContactMainSlider { get; set; }
    }
}
