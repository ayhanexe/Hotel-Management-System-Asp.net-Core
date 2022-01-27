using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomFinder.Models.Entities
{
    public class Layout : BaseEntity
    {
        [Required]
        public string MainSliderTitle { get; set; }

        [Required]
        public string MainSliderDesc { get; set; }

        [Required]
        public string MainSliderImage { get; set; }


        [Required]
        public string RoomImageSliderTitle { get; set; }

        [Required]
        public string RoomImageSliderDesc { get; set; }

        [Required]
        public string RoomSliderTitle { get; set; }

        [Required]
        public string RoomSliderDesc { get; set; }

        [Required]
        public string CommentSliderTitle { get; set; }

        [Required]
        public string CommentSliderDesc { get; set; }

        [Required]
        public string AboutBaseSliderTitle { get; set; }

        [Required]
        public string AboutBaseSliderDescription { get; set; }
        [Required]
        public string AboutBaseSliderPhoto { get; set; }

        [Required]
        public string AboutCEOPhoto { get; set; }

        [Required]
        public string AboutCEOText { get; set; }

        [Required]
        public string AboutCEOName { get; set; }

        [Required]
        public string AboutFeatureTitle { get; set; }


        [Required]
        public string AboutFeatureDescription { get; set; }

        [Required]
        public string AboutVideoPhoto { get; set; }

        [Required]
        public string AboutVideoUrl { get; set; }

        [Required]
        public string AboutVideoTitle { get; set; }

        [Required]
        public string AboutVideoDescription { get; set; }

        [Required]
        public string AboutStaffTitle { get; set; }

        [Required]
        public string AboutStaffDescription { get; set; }

        [Required]
        public List<Staff> Staffs { get; set; }

        [Required]
        public string HotelSliderTitle { get; set; }
        [Required]
        public string HotelSliderDescription { get; set; }
        [Required]
        public string HotelSliderPhoto { get; set; }


        [Required]
        public string RoomsSliderTitle { get; set; }
        [Required]
        public string RoomsSliderDescription { get; set; }
        [Required]
        public string RoomsSliderPhoto { get; set; }

        [Required]
        public string ServicesSliderTitle { get; set; }
        [Required]
        public string ServicesSliderDescription { get; set; }
        [Required]
        public string ServicesSliderPhoto { get; set; }


        [Required]
        public string ContactSliderTitle { get; set; }
        [Required]
        public string ContactSliderDescription { get; set; }
        [Required]
        public string ContactSliderPhoto { get; set; }



        [Required]
        public ICollection<LayoutFeature> Features { get; set; }
    }
}
