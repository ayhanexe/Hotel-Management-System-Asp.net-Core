﻿namespace HotelRoomFinder.Areas.Admin.Model
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool isBlocked { get; set; }
    }
}
