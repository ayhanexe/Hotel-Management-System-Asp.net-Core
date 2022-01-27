using HotelRoomFinder.Models.Entities;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
    }
}
