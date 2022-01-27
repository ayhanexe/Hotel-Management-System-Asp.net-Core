using HotelRoomFinder.Areas.Admin.Model;
using HotelRoomFinder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            var reservations = await _context.Reservations.Include(r => r.User).Include(r => r.Room).Where(r => !r.IsDeleted).ToListAsync();
            if (reservations.Count == 0)
            {
                return RedirectToAction("Index", "Dashboard", new
                {
                    area = "Admin"
                });
            }

            var model = new ReservationViewModel
            {
                Reservations = reservations
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.Where(r => r.Id == id).FirstOrDefaultAsync();

            if (reservation == null)
            {
                return NotFound();
            }

            reservation.IsDeleted = true;
            reservation.DeletedTime = DateTime.Now;
            reservation.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditReservation(int id)
        {
            var reservation = await _context.Reservations.Include(r => r.Room).Where(r => !r.IsDeleted && r.Id == id).FirstOrDefaultAsync();

            if (reservation == null)
            {
                return NotFound();
            }

            var model = new EditReservationViewModel
            {
                Room = reservation.Room,
                id = reservation.Id,
                CheckIn = reservation.CheckInDate,
                CheckOut = reservation.CheckOutDate,
                AdultBedCount = reservation.AdultBedCount,
                KidBedCount = reservation.KidBedCount
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditReservation(int id, EditReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var reservation = await _context.Reservations.Where(r => !r.IsDeleted && r.Id == id).FirstOrDefaultAsync();

            reservation.CheckInDate = model.CheckIn;
            reservation.CheckOutDate = model.CheckOut;
            reservation.AdultBedCount = model.AdultBedCount;
            reservation.KidBedCount = model.KidBedCount;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
