using HotelRoomFinder.Data;
using HotelRoomFinder.Models;
using HotelRoomFinder.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;

        public HomeController(AppDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }



        public async Task<IActionResult> Index()
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);

            return View(layout);
        }

        public async Task<IActionResult> About()
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);

            return View(layout);
        }

        public async Task<IActionResult> Hotels()
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);

            return View(layout);
        }

        [HttpPost]
        public async Task<IActionResult> FilterRoomsForId(int id, HomeIndexViewModel model)
        {
            var checkIn = model?.RoomFilter?.CheckIn;
            var checkOut = model?.RoomFilter?.CheckOut;
            var adultBedCount = model?.RoomFilter?.AdultBedCount;
            var kidBedCount = model?.RoomFilter?.KidBedCount;

            var originalModel = await GeneralUtils.GetHomeIndexViewModelData(_context);
            if (checkIn < DateTime.Now)
            {
                checkIn = DateTime.Now;
            }
            if (checkOut < DateTime.Now)
            {
                checkOut = DateTime.Now.AddDays(1);
            }
            if (checkIn == null)
            {
                ModelState.AddModelError("checkIn", "Please select check-in date");
                return View("Rooms", originalModel);
            }
            if (checkOut == null)
            {
                ModelState.AddModelError("checkIn", "Please select check-out date");
                return View("Rooms", originalModel);
            }
            if (adultBedCount == null)
            {
                ModelState.AddModelError("checkIn", "Please select Adult Bed Count");
                return View("Rooms", originalModel);
            }
            if (kidBedCount == null)
            {
                ModelState.AddModelError("checkIn", "Please select Kid Bed Count");
                return View("Rooms", originalModel);
            }

            var h = await _context.Hotels.Where(h => !h.IsDeleted && h.Id == id).FirstOrDefaultAsync();

            if (h == null)
            {
                return NotFound();
            }

            var _model = await GeneralUtils.GetHomeIndexViewModelData(_context);
            _model.Rooms = await _context.Rooms
                .Include(r => r.Reservations)
                .Include(r => r.Photos)
                .Where(r => !r.IsDeleted && r.Reservations.All(re => checkIn > re.CheckOutDate || re.IsDeleted) && adultBedCount <= r.AdultBedCount && kidBedCount <= r.KidBedCount)
                .ToListAsync();
            _model.area = "";
            _model.id = id;
            _model.Hotel = h;

            return View($"RoomsWithId", _model);
        }

        [HttpGet]
        public async Task<IActionResult> FilterRooms()
        {
            var model = await GeneralUtils.GetHomeIndexViewModelData(_context);
            return View("Rooms", model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterRooms(HomeIndexViewModel model)
        {
            var checkIn = model?.RoomFilter?.CheckIn;
            var checkOut = model?.RoomFilter?.CheckOut;
            var adultBedCount = model?.RoomFilter?.AdultBedCount;
            var kidBedCount = model?.RoomFilter?.KidBedCount;

            var originalModel = await GeneralUtils.GetHomeIndexViewModelData(_context);
            if (checkIn < DateTime.Now)
            {
                checkIn = DateTime.Now;
            }
            if (checkOut < DateTime.Now)
            {
                checkOut = DateTime.Now.AddDays(1);
            }

            if (checkIn == null)
            {
                ModelState.AddModelError("checkIn", "Please select check-in date");
                return View("Rooms", originalModel);
            }
            if (checkOut == null)
            {
                ModelState.AddModelError("checkOut", "Please select check-out date");
                return View("Rooms", originalModel);
            }
            if (adultBedCount == null)
            {
                ModelState.AddModelError("adultBedCount", "Please select Adult Bed Count");
                return View("Rooms", originalModel);
            }
            if (kidBedCount == null)
            {
                ModelState.AddModelError("kidBedCount", "Please select Kid Bed Count");
                return View("Rooms", originalModel);
            }

            var _model = await GeneralUtils.GetHomeIndexViewModelData(_context);
            _model.Rooms = await _context.Rooms
                .Include(r => r.Reservations)
                .Include(r => r.Photos)
                .Where(r => !r.IsDeleted && r.Reservations.All(re => checkIn > re.CheckOutDate || re.IsDeleted) && adultBedCount <= r.AdultBedCount && kidBedCount <= r.KidBedCount)
                .ToListAsync();
            _model.area = "";

            return View("Rooms", _model);
        }
        public async Task<IActionResult> Rooms(int id)
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);

            if (id != 0)
            {
                var h = await _context.Hotels
                    .Include(h => h.Rooms)
                    .ThenInclude(r => r.Hotel)
                    .Include(h => h.Rooms)
                    .ThenInclude(r => r.Photos)
                    .Where(h => !h.IsDeleted && h.Id == id)
                    .FirstOrDefaultAsync();
                layout.Hotel = h;
                if (h == null)
                {
                    return NotFound();
                }

                return View("RoomsWithId", layout);
            }
            else
            {
                return View("Rooms", layout);
            }
        }
        public async Task<IActionResult> Services()
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);

            return View(layout);
        }
        public async Task<IActionResult> Contact()
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);

            return View(layout);
        }

        public async Task<IActionResult> RoomDetail(int id)
        {
            var layout = await GeneralUtils.GetHomeIndexViewModelData(_context);
            var user = await AuthUtils.GetAuthUserFromHttpContext(_http, _context);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            layout.room = await _context.Rooms.Include(r => r.Hotel).Include(r => r.Comments).ThenInclude(c => c.User).Include(r => r.Photos).Include(r => r.Features).ThenInclude(f => f.Feature).Where(r => r.Id == id && !r.IsDeleted).FirstOrDefaultAsync();
            layout.user = user;


            return View(layout);
        }
    }
}
