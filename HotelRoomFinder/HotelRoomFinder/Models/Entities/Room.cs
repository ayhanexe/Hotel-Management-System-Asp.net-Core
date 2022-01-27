using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class Room : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AdultBedCount { get; set; }

        [Required]
        public int KidBedCount { get; set; }

        [Required]
        public int RoomWidth { get; set; }

        [Required]
        public int NightlyPrice { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Count { get; set; } = 1;

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public List<RoomPhoto> Photos { get; set; }
        public List<RoomFeature> Features { get; set; }
        public List<RoomComment> Comments { get; set; }

        [Required]
        public List<Reservation> Reservations { get; set; }
    }
}
