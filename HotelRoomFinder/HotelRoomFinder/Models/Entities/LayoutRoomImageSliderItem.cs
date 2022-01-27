using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class LayoutRoomImageSliderItem : BaseEntity
    {
        [Required]
        public string Image { get; set; }
    }
}
