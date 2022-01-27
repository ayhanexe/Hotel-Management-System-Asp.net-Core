using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class RoomComment : BaseEntity
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int StarCount { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }


        [Required]
        public string Text { get; set; }
    }
}
