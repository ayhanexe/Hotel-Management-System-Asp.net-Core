using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class AspRouteValues : BaseEntity
    {
        [Required]
        public string Controller { get; set; } = "";

        [Required]
        public string Action { get; set; } = "";

        public string Area { get; set; } = "";
    }
}
