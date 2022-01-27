using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class LayoutBlogItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Text { get; set; }

        public IFormFile Image { get; set; }

        public string ButtonText { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }


    }
}
