using Microsoft.AspNetCore.Http;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class HotelEditViewModel
    {
        public string Photo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StarCount { get; set; }
        public IFormFile File { get; set; }
    }
}
