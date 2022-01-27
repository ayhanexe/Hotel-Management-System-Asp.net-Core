using HotelRoomFinder.Data;
using HotelRoomFinder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomFinder.Utils
{
    public static class GeneralUtils
    {
        public static async Task<HomeIndexViewModel> GetHomeIndexViewModelData(AppDbContext _context)
        {
            var layout = new HomeIndexViewModel
            {
                Hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync(),
                Header = await _context.Header.Where(b => !b.IsDeleted).FirstOrDefaultAsync(),
                HeaderItems = await _context.HeaderItems.Where(b => !b.IsDeleted).ToListAsync(),
                Layout = await _context.Layout.Include(l => l.Staffs.Where(s => !s.IsDeleted)).Where(b => !b.IsDeleted).FirstOrDefaultAsync(),
                Footer = await _context.Footer.Where(b => !b.IsDeleted).FirstOrDefaultAsync(),
                Rooms = await _context.Rooms
                                .Include(r => r.Reservations)
                                .Include(r => r.Photos)
                                .Where(r => !r.IsDeleted && r.Reservations.Count == 0 ? !r.IsDeleted : !r.IsDeleted && r.Reservations.All(re => DateTime.Now > re.CheckOutDate || re.IsDeleted))
                                .ToListAsync(),
                BlogItems = await _context.LayoutBlogItems.Where(b => !b.IsDeleted).ToListAsync(),
                Features = await _context.LayoutFeatures.Include(f => f.Feature).Where(b => !b.IsDeleted).ToListAsync(),
                layoutCommentItems = await _context.LayoutCommentItems.Include(a => a.Comment).ThenInclude(a => a.User).Where(b => !b.IsDeleted).ToListAsync(),
                layoutCounterItems = await _context.LayoutCounterItems.Where(b => !b.IsDeleted).ToListAsync(),
                layoutRoomImageSliderItems = await _context.LayoutRoomImageSliderItems.Where(b => !b.IsDeleted).ToListAsync(),
            };

            return layout;
        }
        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }
    }
}
