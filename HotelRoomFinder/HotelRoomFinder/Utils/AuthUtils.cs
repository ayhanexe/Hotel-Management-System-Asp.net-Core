using HotelRoomFinder.Data;
using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelRoomFinder.Utils
{
    public static class AuthUtils
    {
        public static async Task<User> GetAuthUserFromHttpContext(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            string authUserEmail = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var authUser = await context.Users.Where(p => p.Email == authUserEmail).FirstOrDefaultAsync();

            return authUser;
        }
    }
}
