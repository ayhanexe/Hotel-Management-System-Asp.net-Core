using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class Hotel : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int StarCount { get; set; }

        [Required]
        public string Photo { get; set; }

        public string UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
