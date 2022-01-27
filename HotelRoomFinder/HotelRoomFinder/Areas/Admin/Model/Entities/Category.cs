using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Areas.Admin.Model.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Icon { get; set; }


        [Required]
        public string Controller { get; set; }

        [Required]
        public string Action { get; set; }
        public bool isDropdown { get; set; } = false;

        ICollection<DropdownItem> DropdownItems { get; set; }
    }
}
