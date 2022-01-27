using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class LayoutFeature : BaseEntity
    {
        [Required]
        public int FeatureId { get; set; }

        [Required]
        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
    }
}
