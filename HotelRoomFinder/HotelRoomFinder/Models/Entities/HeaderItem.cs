using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class HeaderItem : AspRouteValues
    {
        [Required]
        public string Name { get; set; }
    }
}
