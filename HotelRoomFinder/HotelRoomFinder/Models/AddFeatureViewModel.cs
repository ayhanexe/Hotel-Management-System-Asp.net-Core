using HotelRoomFinder.Models.Entities;
using System.Collections.Generic;

namespace HotelRoomFinder.Models
{
    public class AddFeatureViewModel
    {
        public Room Room { get; set; }
        public List<Feature> Features { get; set; }
    }
}
