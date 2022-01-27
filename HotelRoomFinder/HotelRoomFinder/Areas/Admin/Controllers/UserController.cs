using HotelRoomFinder.Areas.Admin.Model;
using HotelRoomFinder.Constants;
using HotelRoomFinder.Data;
using HotelRoomFinder.Models.Entities;
using HotelRoomFinder.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(AppDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Where(u => !u.isDeleted).ToListAsync();
            var model = new List<UserViewModel>();

            foreach (var user in users)
            {
                model.Add(new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Role = (await _userManager.GetRolesAsync(user))[0],
                    isBlocked = user.isBlocked
                });

            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _context.Users.FindAsync(id);

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                isBlocked = user.isBlocked,
                Role = (await _userManager.GetRolesAsync(user))[0],
            };

            var Roles = await _context.Roles.ToListAsync();

            var model = new EditUserViewModel
            {
                User = userViewModel,
                Roles = Roles
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _context.Users.FindAsync(model.User.Id);

            user.FullName = model.User.FullName ?? "";
            user.Email = model.User.Email;
            user.UserName = model.User.UserName ?? "";

            var oldRole = (await _userManager.GetRolesAsync(user))[0];
            var newRole = (await _context.Roles.FindAsync(model.User.Role)).Name;

            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, newRole ?? RoleConstants.User);

            user.isBlocked = model.User.isBlocked || false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> ActivateUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            user.isBlocked = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> BlockUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            string authUserEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var authUser = _context.Users.Where(p => p.Email == authUserEmail).FirstOrDefault();

            user.isBlocked = true;

            await _context.SaveChangesAsync();

            if (authUser.Email == user.Email)
            {
                return RedirectToAction("Logout", "Account", new
                {
                    area = ""
                });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.Where(h => h.UserId == user.Id && !h.IsDeleted).FirstOrDefaultAsync();

            if (hotel != null)
            {
                hotel.IsDeleted = true;
                hotel.DeletedTime = DateTime.Now;
                hotel.LastUpdated = DateTime.Now;
            }

            user.isDeleted = true;


            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> InsertDummyData()
        {
            var FullName = $"{GeneralUtils.GenerateName(5)}";
            var UserName = $"{GeneralUtils.GenerateName(5)}";
            var email = $"{GeneralUtils.GenerateName(5)}@{GeneralUtils.GenerateName(5)}.com";

            User user = new User
            {
                FullName = FullName,
                UserName = UserName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, "dummy12345678!");

            await _context.SaveChangesAsync();
            var dbUser = await _context.Users.Where(p => p.Email == user.Email).FirstOrDefaultAsync();
            await _userManager.AddToRoleAsync(dbUser, RoleConstants.User);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Moderator, Manager, User")]
        public async Task<IActionResult> UserSettings()
        {
            var user = await AuthUtils.GetAuthUserFromHttpContext(_httpContextAccessor, _context);

            if (user == null)
            {
                return NotFound();
            }

            var model = new SettingsViewModel
            {
                AuthUserData = user,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator, Manager, User")]
        public async Task<IActionResult> SaveSettings(SettingsViewModel model)
        {
            var user = await AuthUtils.GetAuthUserFromHttpContext(_httpContextAccessor, _context);

            if (string.IsNullOrEmpty(model.FullName))
            {
                model.FullName = "";
            }

            if (user == null)
            {
                return NotFound();
            }

            user.FullName = model.FullName;

            if (model.Photo != null)
            {
                if (user.Photo != "default-avatar.jpg")
                {
                    await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, user.Photo));
                }
                var fileName = await FileUtils.CopyFile(model.Photo, FileConstants.ImagePath);
                user.Photo = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("UserSettings");
        }
    }
}
