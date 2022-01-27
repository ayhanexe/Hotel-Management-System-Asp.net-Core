using HotelRoomFinder.Areas.Admin.Model;
using HotelRoomFinder.Data;
using HotelRoomFinder.Models;
using HotelRoomFinder.Models.Entities;
using HotelRoomFinder.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;

        public CommentController(AppDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        public async Task<IActionResult> Add(HomeIndexViewModel model)
        {
            var user = await AuthUtils.GetAuthUserFromHttpContext(_http, _context);
            var room = await _context.Rooms.Where(r => !r.IsDeleted && r.Id == model.commentViewModel.RoomId).FirstOrDefaultAsync();

            if (room == null)
            {
                return RedirectToAction("RoomDetail", "Home", new
                {
                    area = "",
                    id = room.Id
                });
            }

            if (user == null)
            {
                return RedirectToAction("RoomDetail", "Home", new
                {
                    area = "",
                    id = room.Id
                });
            }

            if (string.IsNullOrEmpty(model.commentViewModel.Name))
            {
                ModelState.AddModelError("", "Comment Name cannot be null!");
                return RedirectToAction("RoomDetail", "Home", new
                {
                    area = "",
                    id = room.Id
                });
            }
            if (string.IsNullOrEmpty(model.commentViewModel.Email))
            {
                ModelState.AddModelError("", "Comment Email cannot be null!");
                return RedirectToAction("RoomDetail", "Home", new
                {
                    area = "",
                    id = room.Id
                });
            }
            if (string.IsNullOrEmpty(model.commentViewModel.Text))
            {
                ModelState.AddModelError("", "Comment Text cannot be null!");
                return RedirectToAction("RoomDetail", "Home", new
                {
                    area = "",
                    id = room.Id
                });
            }

            var comment = new RoomComment
            {
                User = user,
                Room = room,
                StarCount = 5,
                Text = model.commentViewModel.Text,
                Name = model.commentViewModel.Name,
                Email = model.commentViewModel.Email
            };

            await _context.RoomComments.AddAsync(comment);

            await _context.SaveChangesAsync();

            return RedirectToAction("RoomDetail", "Home", new
            {
                area = "",
                id = room.Id
            });
        }

        public async Task<IActionResult> List(int id)
        {
            var comments = await _context.RoomComments.Include(rc => rc.Room).Include(rc => rc.User).Where(r => !r.IsDeleted && r.RoomId == id).ToListAsync();

            return View(comments);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.RoomComments.Where(rc => !rc.IsDeleted && rc.Id == id).FirstOrDefaultAsync();

            if (comment == null)
            {
                return NotFound();
            }

            var roomId = comment.RoomId;
            comment.IsDeleted = true;
            comment.DeletedTime = DateTime.Now;
            comment.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("List", new
            {
                id = roomId
            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var comment = await _context.RoomComments.Include(rc => rc.Room).Include(rc => rc.User).Where(rc => !rc.IsDeleted && rc.Id == id).FirstOrDefaultAsync();

            if (comment == null)
            {
                return NotFound();
            }

            var model = new EditCommentViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
                User = comment.User
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(int id, EditCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var comment = await _context.RoomComments.Where(rc => !rc.IsDeleted && rc.Id == id).FirstOrDefaultAsync();

            if (comment == null)
            {
                return NotFound();
            }

            comment.Text = model.Text;
            await _context.SaveChangesAsync();

            return RedirectToAction("List", new
            {
                id = comment.RoomId
            });
        }
    }
}
