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
using HotelRoomFinder.Models;
using System.IO;

namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Add(int id)
        {
            var hotel = await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return NotFound();
            }

            var model = new RoomCreateViewModel
            {
                Hotel = hotel,
                Room = null,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, RoomCreateViewModel model)
        {
            var hotel = await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return RedirectToAction("Index", "Hotel");
            }

            var failViewData = new RoomCreateViewModel
            {
                Hotel = hotel,
                Room = model.Room
            };

            if (string.IsNullOrEmpty(model.Room.Name))
            {
                ModelState.AddModelError("Name", "Room Name wont be empty!");
                return View(failViewData);
            }
            if (string.IsNullOrEmpty(model.Room.Title))
            {
                ModelState.AddModelError("Title", "Room Title wont be empty!");
                return View(failViewData);
            }
            if (string.IsNullOrEmpty(model.Room.Description))
            {
                ModelState.AddModelError("Description", "Room Description wont be empty!");
                return View(failViewData);
            }
            if (model.Room.RoomWidth < 0)
            {
                ModelState.AddModelError("RoomWidth", "Room Width wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.AdultBedCount < 0)
            {
                ModelState.AddModelError("AdultBedCount", "Adult Bed Count wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.KidBedCount < 0)
            {
                ModelState.AddModelError("KidBedCount", "Kid Bed Count wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.NightlyPrice < 0)
            {
                ModelState.AddModelError("NightlyPrice", "Nightly Price wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.Count < 0)
            {
                ModelState.AddModelError("Count", "Room Count wont be lower than 0!");
                return View(failViewData);
            }


            var newRoom = new Room
            {
                Name = model.Room.Name,
                Title = model.Room.Title,
                Description = model.Room.Description,
                RoomWidth = model.Room.RoomWidth,
                AdultBedCount = model.Room.AdultBedCount,
                KidBedCount = model.Room.KidBedCount,
                NightlyPrice = model.Room.NightlyPrice,
                Count = model.Room.Count,
                Hotel = hotel
            };

            await _context.Rooms.AddAsync(newRoom);

            if (model.Room.Photos.Length > 0 || model.Room.Photos != null)
            {
                foreach (var photo in model.Room.Photos)
                {
                    var photoName = await FileUtils.CopyFile(photo, FileConstants.ImagePath);

                    var RoomPhoto = new RoomPhoto
                    {
                        Room = newRoom,
                        Photo = photoName,
                    };

                    await _context.RoomPhotos.AddAsync(RoomPhoto);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("AddFeature", new
            {
                id = newRoom.Id
            });
        }

        public async Task<IActionResult> AddFeature(int id)
        {
            var room = await _context.Rooms.Where(r => !r.IsDeleted && r.Id == id).FirstOrDefaultAsync();
            var features = await _context.RoomFeatures.Where(r => !r.IsDeleted && r.RoomId == id).ToListAsync();

            room.Features = features;

            var model = new AddFeatureViewModel
            {
                Room = room,
                Features = (await _context.Features.Where(f => !f.IsDeleted).ToListAsync())
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature(int id, int roomId)
        {
            var room = await _context.Rooms.Where(r => !r.IsDeleted && r.Id == roomId).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            var feature = await _context.Features.Where(f => !f.IsDeleted && f.Id == id).FirstOrDefaultAsync();

            if (feature == null)
            {
                return NotFound();
            }

            var _rf = await _context.RoomFeatures.Where(rf => !rf.IsDeleted && rf.RoomId == roomId && rf.FeatureId == id).FirstOrDefaultAsync();
            Console.WriteLine(_rf);

            if (_rf != null)
            {
                return StatusCode(400, "Feature added already!");
            }

            var roomFeature = new RoomFeature
            {
                Feature = feature,
                Room = room
            };

            await _context.RoomFeatures.AddAsync(roomFeature);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var roomFeature = await _context.RoomFeatures.Where(r => r.Id == id).FirstOrDefaultAsync();

            if (roomFeature == null)
            {
                return NotFound();
            }

            roomFeature.IsDeleted = true;
            roomFeature.DeletedTime = DateTime.Now;
            roomFeature.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var room = await _context.Rooms
                            .Include(r => r.Hotel)
                            .Include(r => r.Features)
                            .ThenInclude(r => r.Feature)
                            .Include(r => r.Photos.Where(p => !p.IsDeleted))
                            .Where(r => !r.IsDeleted && r.Id == id)
                            .FirstOrDefaultAsync();
            var features = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();
            if (room == null)
            {
                return NotFound();
            }

            var model = new RoomSelfViewModel
            {
                Features = features,
                BaseRoomData = room,
                Name = room.Name,
                Title = room.Title,
                Description = room.Description,
                AdultBedCount = room.AdultBedCount,
                KidBedCount = room.KidBedCount,
                NightlyPrice = room.NightlyPrice,
                Count = room.Count,
                Hotel = room.Hotel,
                RoomWidth = room.RoomWidth
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomCreateViewModel model)
        {
            var hotel = await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync();

            if (hotel == null)
            {
                return RedirectToAction("Index", "Hotel");
            }

            var failViewData = new RoomCreateViewModel
            {
                Hotel = hotel,
                Room = model.Room
            };

            if (string.IsNullOrEmpty(model.Room.Name))
            {
                ModelState.AddModelError("Name", "Room Name wont be empty!");
                return View(failViewData);
            }
            if (string.IsNullOrEmpty(model.Room.Title))
            {
                ModelState.AddModelError("Title", "Room Title wont be empty!");
                return View(failViewData);
            }
            if (string.IsNullOrEmpty(model.Room.Description))
            {
                ModelState.AddModelError("Description", "Room Description wont be empty!");
                return View(failViewData);
            }
            if (model.Room.RoomWidth < 0)
            {
                ModelState.AddModelError("RoomWidth", "Room Width wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.AdultBedCount < 0)
            {
                ModelState.AddModelError("AdultBedCount", "Adult Bed Count wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.KidBedCount < 0)
            {
                ModelState.AddModelError("KidBedCount", "Kid Bed Count wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.NightlyPrice < 0)
            {
                ModelState.AddModelError("NightlyPrice", "Nightly Price wont be lower than 0!");
                return View(failViewData);
            }
            if (model.Room.Count < 0)
            {
                ModelState.AddModelError("Count", "Room Count wont be lower than 0!");
                return View(failViewData);
            }


            var newRoom = new Room
            {
                Name = model.Room.Name,
                Title = model.Room.Title,
                Description = model.Room.Description,
                RoomWidth = model.Room.RoomWidth,
                AdultBedCount = model.Room.AdultBedCount,
                KidBedCount = model.Room.KidBedCount,
                NightlyPrice = model.Room.NightlyPrice,
                Count = model.Room.Count,
                Hotel = hotel
            };

            await _context.Rooms.AddAsync(newRoom);

            if (model.Room.Photos.Length > 0 || model.Room.Photos != null)
            {
                foreach (var photo in model.Room.Photos)
                {
                    var photoName = await FileUtils.CopyFile(photo, FileConstants.ImagePath);

                    var RoomPhoto = new RoomPhoto
                    {
                        Room = newRoom,
                        Photo = photoName,
                    };

                    await _context.RoomPhotos.AddAsync(RoomPhoto);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("AddFeature", new
            {
                id = newRoom.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> RemovePhoto(int id, int roomId)
        {
            var photo = (await _context.Rooms.Include(r => r.Photos).Where(r => r.Id == roomId && !r.IsDeleted).FirstOrDefaultAsync()).Photos.Where(p => p.Id == id).FirstOrDefault();

            if (photo == null)
            {
                return NotFound();
            }

            photo.IsDeleted = true;
            photo.DeletedTime = DateTime.Now;
            photo.LastUpdated = DateTime.Now;

            await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, photo.Photo));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(int id, RoomSelfViewModel model)
        {
            var room = await _context.Rooms.Include(r => r.Photos).Include(r => r.Hotel).Where(r => r.Id == id && !r.IsDeleted).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                room.Name = model.Name;
            }

            if (!string.IsNullOrEmpty(model.Title))
            {
                room.Title = model.Title;
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                room.Description = model.Description;
            }

            room.AdultBedCount = model.AdultBedCount;

            room.KidBedCount = model.KidBedCount;

            room.RoomWidth = model.RoomWidth;

            room.NightlyPrice = model.NightlyPrice;

            room.Count = model.Count;

            if (model.Photos != null)
            {
                foreach (var photo in model.Photos)
                {
                    var fileName = await FileUtils.CopyFile(photo, FileConstants.ImagePath);
                    var roomPhoto = new RoomPhoto
                    {
                        Photo = fileName,
                        Room = room,
                    };

                    await _context.RoomPhotos.AddAsync(roomPhoto);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Room", new
            {
                id = room.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRoom(int id)
        {
            var room = await _context.Rooms.Include(r => r.Hotel).Where(r => r.Id == id).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            room.IsDeleted = true;
            room.DeletedTime = DateTime.Now;
            room.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("ViewHotelRooms", "Hotel", new
            {
                id = room.Hotel.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(int id, HomeIndexViewModel model)
        {
            var user = await _context.Users.Where(u => u.Id == model.reserve.UserId).FirstOrDefaultAsync();

            if (model.reserve.CheckIn < DateTime.Now || model.reserve.CheckOut < DateTime.Now)
            {
                return RedirectToAction("Rooms", "Home", new
                {
                    area = ""
                });
            }

            var room = await _context.Rooms.Include(r => r.Reservations)
                            .Where(r => !r.IsDeleted && r.Reservations.All(re => model.reserve.CheckIn > re.CheckOutDate))
                            .FirstOrDefaultAsync();

            if (room == null)
            {
                return RedirectToAction("Rooms", "Home", new
                {
                    area = ""
                });
            }

            if (user == null)
            {
                return NotFound();
            }

            if (model.reserve.CheckOut < model.reserve.CheckIn)
            {
                ModelState.AddModelError("", "CheckOut cannot be lower than check in");
                return RedirectToAction("Rooms", "Home", new
                {
                    area = ""
                });
            }
            if (model.reserve.CheckIn < DateTime.Now)
            {
                ModelState.AddModelError("", "CheckIn cannot be lower than current time");
                return RedirectToAction("Rooms", "Home", new
                {
                    area = ""
                });
            }
            if (model.reserve.CheckOut <= DateTime.Now)
            {
                ModelState.AddModelError("", "CheckOut cannot be lower than current time!");
                return RedirectToAction("Rooms", "Home", new
                {
                    area = ""
                });
            }

            if (room == null)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                CheckInDate = model.reserve.CheckIn,
                CheckOutDate = model.reserve.CheckOut,
                User = user,
                UserId = user.Id,
                Room = room,
                AdultBedCount = model.reserve.AdultBedCount,
                KidBedCount = model.reserve.KidBedCount,
            };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Rooms", "Home", new
            {
                area = ""
            });
        }
    }
}
