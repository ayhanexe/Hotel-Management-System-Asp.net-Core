using HotelRoomFinder.Constants;
using HotelRoomFinder.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomFinder.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public DataInitializer(AppDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            _dbContext.Database.Migrate();

            if (!_dbContext.Features.Any())
            {
                var featureData = new List<Feature>()
                {
                new Feature {
                    Icon = "1.svg",
                    Name = "Havalimanı tarnsferi"
                },
                    new Feature {
                        Icon = "2.svg",
                        Name = "Hər şey daxildir"
                    },
                    new Feature {
                        Icon = "3.svg",
                        Name = "Kondisioner"
                    },
                    new Feature {
                        Icon = "4.svg",
                        Name = "Təhlükəsizlik"
                    },
                    new Feature{
                        Icon = "5.svg",
                        Name = "Qapalı Hovuz"
                    },
                    new Feature {
                        Icon = "6.svg",
                        Name = "Wi-fi"
                    },
                    new Feature{
                        Icon = "7.svg",
                        Name = "Smart TV"
                    },
                    new Feature{
                        Icon = "8.svg",
                        Name = "Çamaşırxana"
                    },
                };

                foreach (Feature _featureData in featureData)
                {
                    await _dbContext.Features.AddAsync(_featureData);
                }
            }


            if (!_dbContext.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Moderator));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Manager));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstants.User));
            }

            if (!_dbContext.Users.Any())
            {
                User user = new User
                {
                    FullName = "Admin",
                    UserName = "Admin",
                    Email = "admin@hotel.com"
                };

                await _userManager.CreateAsync(user, "b911-h4rt-owd1");
                await _userManager.AddToRoleAsync(user, RoleConstants.Admin);
            }

            _dbContext.SaveChanges();
        }

    }
}
