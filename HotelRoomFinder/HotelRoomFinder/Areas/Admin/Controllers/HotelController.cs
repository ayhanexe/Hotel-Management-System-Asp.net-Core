using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelRoomFinder.Utils;
using HotelRoomFinder.Data;
using System.Threading.Tasks;
using HotelRoomFinder.Areas.Admin.Model;
using HotelRoomFinder.Models.Entities;
using HotelRoomFinder.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public HotelController(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await AuthUtils.GetAuthUserFromHttpContext(_httpContextAccessor, _context);

            if (user == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.Where(h => h.UserId == user.Id && !h.IsDeleted).FirstOrDefaultAsync();


            if (hotel == null)
            {
                return NotFound();
            }

            if (user.isHotelAccountInitialized)
            {
                var rooms = await _context.Rooms.Where(p => !p.IsDeleted && p.HotelId == hotel.Id).ToListAsync();
                hotel.Rooms = rooms;

                return View(hotel);
            }
            else
            {
                return RedirectToAction(nameof(InitializeHotel));
            }
        }

        public async Task<IActionResult> InitializeHotel()
        {
            var user = await AuthUtils.GetAuthUserFromHttpContext(_httpContextAccessor, _context);

            if (user.isHotelAccountInitialized)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitializeHotel(HotelCreateViewModel model)
        {
            var user = await AuthUtils.GetAuthUserFromHttpContext(_httpContextAccessor, _context);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Name field is required!");
                return View();
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError(nameof(model.Description), "Description field is required!");
                return View();
            }

            var fileName = await FileUtils.CopyFile(model.File, FileConstants.ImagePath);

            var hotel = new Hotel
            {
                Photo = fileName,
                Name = model.Name,
                Description = model.Description,
                StarCount = model.StarCount,
                User = user
            };

            await _context.Hotels.AddAsync(hotel);

            user.isHotelAccountInitialized = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Hotel");
        }

        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> List()
        {
            var hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync();
            var model = new List<Hotel> { };

            foreach (var hotel in hotels)
            {
                model.Add(new Hotel
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Photo = hotel.Photo,
                    StarCount = hotel.StarCount,
                    IsDeleted = hotel.IsDeleted,
                    CreatedTime = hotel.CreatedTime,
                    DeletedTime = hotel.DeletedTime,
                    Description = hotel.Description,
                    LastUpdated = hotel.LastUpdated,
                    User = (await _context.Users.Where(u => u.Id == hotel.UserId).FirstOrDefaultAsync()),
                    UserId = hotel.UserId,
                });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Where(u => u.Id == hotel.UserId).FirstOrDefaultAsync();
            var rooms = await _context.Rooms.Where(r => r.HotelId == hotel.Id && !r.IsDeleted).ToListAsync();

            foreach (var room in rooms)
            {
                room.IsDeleted = true;
                room.DeletedTime = DateTime.Now;
                room.LastUpdated = DateTime.Now;

                var features = _context.RoomFeatures.Where(rf => rf.RoomId == room.Id);

                foreach (var feature in features)
                {
                    feature.IsDeleted = true;
                    feature.DeletedTime = DateTime.Now;
                    feature.LastUpdated = DateTime.Now;
                }
            }

            if (user == null)
            {
                return NotFound();
            }

            hotel.IsDeleted = true;
            hotel.DeletedTime = DateTime.Now;
            hotel.LastUpdated = DateTime.Now;

            user.isHotelAccountInitialized = false;

            await _context.SaveChangesAsync();

            return Ok();
        }

        public async Task<IActionResult> UpdateHotel(int id)
        {
            var hotel = await _context.Hotels.Where(h => !h.IsDeleted && h.Id == id).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return NotFound();
            }
            var model = new HotelEditViewModel
            {
                Photo = hotel.Photo,
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                StarCount = hotel.StarCount,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHotel(int id, HotelEditViewModel model)
        {
            var hotel = await _context.Hotels.Where(h => !h.IsDeleted && h.Id == id).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return NotFound();
            }

            hotel.Name = model.Name;
            hotel.Description = model.Description;
            hotel.StarCount = model.StarCount;

            if (model.File != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, hotel.Photo));
                var fileName = await FileUtils.CopyFile(model.File, FileConstants.ImagePath);
                hotel.Photo = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> ViewHotelRooms(int id)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Rooms.Where(r => !r.IsDeleted))
                .ThenInclude(r => r.Features.Where(f => !f.IsDeleted))
                .ThenInclude(f => f.Feature)
                .Include(h => h.Rooms.Where(r => !r.IsDeleted))
                .ThenInclude(h => h.Photos)
                .Where(h => h.Id == id && !h.IsDeleted)
                .FirstOrDefaultAsync();

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }
    }
}
