using HotelRoomFinder.Models.Entities;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class RoomCreateViewModel
    {
        public Hotel Hotel { get; set; }
        public RoomSelfViewModel Room { get; set; }
    }
}
