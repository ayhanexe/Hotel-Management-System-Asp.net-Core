using System;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Areas.Admin.Model.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedTime { get; set; }

        public DateTime? LastUpdated { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
