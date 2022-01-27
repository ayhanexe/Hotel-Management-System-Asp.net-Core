using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class RoomPhoto : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        public string Photo { get; set; }
    }
}
