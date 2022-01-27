using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class RoomFeature : BaseEntity
    {
        public int RoomId { get; set; }

        [Required]
        [ForeignKey("RoomId")]
        public Room Room { get; set; }


        public int FeatureId { get; set; }

        [Required]
        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
    }
}
