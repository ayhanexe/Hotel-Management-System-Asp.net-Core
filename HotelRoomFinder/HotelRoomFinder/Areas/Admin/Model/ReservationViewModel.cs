using HotelRoomFinder.Models.Entities;
using System.Collections.Generic;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class ReservationViewModel
    {
        public List<Reservation> Reservations { get; set; }
    }
}
