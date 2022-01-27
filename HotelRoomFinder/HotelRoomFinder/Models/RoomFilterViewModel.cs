using System;

namespace HotelRoomFinder.Models
{
    public class RoomFilterViewModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultBedCount { get; set; }
        public int KidBedCount { get; set; }
    }
}
