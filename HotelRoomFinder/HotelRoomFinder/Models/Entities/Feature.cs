using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class Feature : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Icon { get; set; }
    }
}
