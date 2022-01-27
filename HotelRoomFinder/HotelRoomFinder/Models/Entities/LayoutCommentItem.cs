using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomFinder.Models.Entities
{
    public class LayoutCommentItem : BaseEntity
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        [ForeignKey("CommentId")]
        public RoomComment Comment { get; set; }
    }
}
