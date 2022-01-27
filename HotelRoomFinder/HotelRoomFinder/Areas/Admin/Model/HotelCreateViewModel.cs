using Microsoft.AspNetCore.Http;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class HotelCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StarCount { get; set; }
        public IFormFile File { get; set; }
    }
}
