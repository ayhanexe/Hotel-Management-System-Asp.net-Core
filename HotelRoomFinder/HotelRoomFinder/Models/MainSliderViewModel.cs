using Microsoft.AspNetCore.Http;

namespace HotelRoomFinder.Models
{
    public class MainSliderViewModel
    {
        public string MainSliderTitle { get; set; }
        public string MainSliderDescription { get; set; }
        public IFormFile MainSliderPhoto { get; set; }
    }
}
