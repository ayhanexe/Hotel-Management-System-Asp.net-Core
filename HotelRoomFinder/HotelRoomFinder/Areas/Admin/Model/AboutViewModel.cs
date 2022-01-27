using HotelRoomFinder.Models;
using Microsoft.AspNetCore.Http;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class AboutViewModel
    {
        public string AboutBaseSliderTitle { get; set; }

        public string AboutBaseSliderDescription { get; set; }
        public IFormFile AboutBaseSliderPhoto { get; set; }

        public IFormFile AboutCEOPhoto { get; set; }

        public string AboutCEOText { get; set; }
        public string AboutCEOName { get; set; }
        public string AboutFeatureTitle { get; set; }
        public string AboutFeatureDescription { get; set; }
        public IFormFile AboutVideoPhoto { get; set; }
        public string AboutVideoUrl { get; set; }
        public string AboutVideoTitle { get; set; }
        public string AboutVideoDescription { get; set; }
        public string AboutStaffTitle { get; set; }
        public string AboutStaffDescription { get; set; }
    }
}
