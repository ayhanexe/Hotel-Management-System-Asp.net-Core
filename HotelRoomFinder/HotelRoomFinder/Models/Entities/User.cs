using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class User : IdentityUser
    {

        [Required]
        public string FullName { get; set; }

        [Required]
        public bool isBlocked { get; set; } = false;

        [Required]
        public bool isHotelAccountInitialized { get; set; } = false;

        [Required]
        public string Photo { get; set; } = "default-avatar.jpg";

        [Required]
        public bool isDeleted { get; set; } = false;
    }
}
