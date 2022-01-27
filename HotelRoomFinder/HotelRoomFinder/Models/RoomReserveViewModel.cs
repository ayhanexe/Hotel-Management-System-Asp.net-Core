using System;

namespace HotelRoomFinder.Models
{
    public class RoomReserveViewModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultBedCount { get; set; }
        public int KidBedCount { get; set; }
        public string UserId { get; set; }
    }
}
