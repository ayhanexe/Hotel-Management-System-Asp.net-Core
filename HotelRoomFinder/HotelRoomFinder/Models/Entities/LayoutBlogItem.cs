using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class LayoutBlogItem : AspRouteValues
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string ButtonText { get; set; }

    }
}
