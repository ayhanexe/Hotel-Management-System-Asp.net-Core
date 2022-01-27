using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class LayoutCounterItem : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int Value { get; set; } = 0;
    }
}
