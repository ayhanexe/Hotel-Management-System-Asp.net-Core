using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class LayoutRoomSliderItem : BaseEntity
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
