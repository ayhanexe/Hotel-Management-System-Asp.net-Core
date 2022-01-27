using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; }

        [Required, ForeignKey("UserId")]
        public User User { get; set; }

        public int RoomId { get; set; }
        public int AdultBedCount { get; set; }
        public int KidBedCount { get; set; }

        [Required, ForeignKey("RoomId")]
        public Room Room { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }
    }
}
