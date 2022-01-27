using HotelRoomFinder.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.AdminCategories.ToListAsync();
            return View(categories);
        }
    }
}
