using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HotelRoomFinder.Areas.Admin.Model
{
    public class EditUserViewModel
    {
        public UserViewModel User { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
