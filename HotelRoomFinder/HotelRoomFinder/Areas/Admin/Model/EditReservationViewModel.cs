using HotelRoomFinder.Models.Entities;
using System;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class EditReservationViewModel
    {
        public Room Room { get; set; }
        public int id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultBedCount { get; set; }
        public int KidBedCount { get; set; }
    }
}
