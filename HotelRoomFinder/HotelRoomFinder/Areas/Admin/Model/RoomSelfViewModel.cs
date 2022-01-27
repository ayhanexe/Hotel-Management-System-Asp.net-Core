using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class RoomSelfViewModel
    {
        public List<Feature> Features { get; set; }
        public Room BaseRoomData { get; set; }
        public Hotel Hotel { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RoomWidth { get; set; }
        public int AdultBedCount { get; set; }
        public int KidBedCount { get; set; }
        public int NightlyPrice { get; set; }
        public int Count { get; set; }
        public IFormFile[] Photos { get; set; }
    }
}
