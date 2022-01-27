using HotelRoomFinder.Constants;
using HotelRoomFinder.Models;
using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRoomFinder.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountRegisterAndLoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(model.LoginModel.Username);

            if(user == null)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            if(user.isBlocked)
            {
                ModelState.AddModelError("", "User is blocked!");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.LoginModel.Password, false, false);

            if(!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials!");
                return View();
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterAndLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            var dbUser = await _userManager.FindByEmailAsync(model.RegisterModel.Email);

            if (dbUser != null)
            {
                ModelState.AddModelError(
                    nameof(model.RegisterModel.Email),
                    "The user with this email is already exists!"
                );

                return View("Login", model);
            }

            User user = new User
            {
                FullName = "",
                UserName = model.RegisterModel.Username,
                Email = model.RegisterModel.Email
            };

            var identityResult = await _userManager.CreateAsync(user, model.RegisterModel.Password);
            await _userManager.AddToRoleAsync(user, RoleConstants.User);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("Login", model);
            }

            await _signInManager.SignInAsync(user, true);
            await _userManager.AddToRoleAsync(user, RoleConstants.User);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            TempData["Error"] = "Access Denied!";

            return RedirectToAction("Index", "Home");
        }
    }
}
