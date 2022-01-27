using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class SettingsViewModel
    {
        public User AuthUserData { get; set; }
        public string FullName { get; set; }

        public IFormFile Photo { get; set; }

    }
}
