using HotelRoomFinder.Areas.Admin.Model;
using HotelRoomFinder.Constants;
using HotelRoomFinder.Data;
using HotelRoomFinder.Models.Entities;
using HotelRoomFinder.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoomFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LayoutController : Controller
    {
        private readonly AppDbContext _context;

        public LayoutController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var header = await _context.Header.Where(h => !h.IsDeleted).FirstOrDefaultAsync();
            var headerItems = await _context.HeaderItems.Where(h => !h.IsDeleted).ToListAsync();
            var mainLayoutData = await _context.Layout.Where(b => !b.IsDeleted).FirstOrDefaultAsync();
            var roomImageSliderItems = await _context.LayoutRoomImageSliderItems.Where(b => !b.IsDeleted).ToListAsync();
            var layoutCommentItems = await _context.LayoutCommentItems.Where(b => !b.IsDeleted).ToListAsync();
            var layoutBlogItems = await _context.LayoutBlogItems.Where(b => !b.IsDeleted).ToListAsync();
            var features = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();
            var layoutFeatures = await _context.LayoutFeatures.Where(f => !f.IsDeleted).ToListAsync();
            var footer = await _context.Footer.Where(f => !f.IsDeleted).FirstOrDefaultAsync();

            LayoutViewModel model = new LayoutViewModel
            {
                Footer = footer,
                Features = features,
                LayoutFeatures = layoutFeatures,
                MainLayout = mainLayoutData,
                BaseHeader = header,
                HeaderItems = headerItems,
                Layout = new MainLayoutViewModel
                {
                    MainSliderTitle = mainLayoutData?.MainSliderTitle ?? "",
                    MainSliderDesc = mainLayoutData?.MainSliderDesc ?? "",
                    RoomImageSliderTitle = mainLayoutData?.RoomImageSliderTitle ?? "",
                    RoomImageSliderDesc = mainLayoutData?.RoomImageSliderDesc ?? "",
                    RoomSliderTitle = mainLayoutData?.RoomSliderTitle ?? "",
                    RoomSliderDesc = mainLayoutData?.RoomSliderDesc ?? "",
                    CommentSliderTitle = mainLayoutData?.CommentSliderTitle ?? "",
                    CommentSliderDesc = mainLayoutData?.CommentSliderDesc ?? "",
                },
                RoomImageSliderItems = roomImageSliderItems,
                LayoutCommentItems = layoutCommentItems,
                LayoutBlogItems = layoutBlogItems
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHeader(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.Header.File == null)
            {
                ModelState.AddModelError("HeaderLogoFile", "Please Select Image!");
                return View();
            }

            if (!model.Header.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("HeaderLogoFile", "Unsupported File Type!");
                return View();
            }

            if (model.Header.File.Length > 1024 * 1000)
            {
                ModelState.AddModelError("HeaderLogoFile", "File size must be lower than 1mb!");
                return View();
            }
            var header = await _context.Header.FirstOrDefaultAsync();
            var fileName = await FileUtils.CopyFile(model.Header.File, FileConstants.ImagePath);

            if (header == null)
            {
                var newHeader = new Header
                {
                    Logo = fileName
                };
                await _context.Header.AddAsync(newHeader);
            }
            else
            {
                try
                {
                    await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, header.Logo));
                }
                catch (Exception e)
                {

                }
                header.Logo = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditHeaderItem(int id)
        {
            var headerItem = await _context.HeaderItems.Where(h => !h.IsDeleted && h.Id == id).FirstOrDefaultAsync();

            if (headerItem == null)
            {
                return NotFound();
            }

            return View(headerItem);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeaderItem(int id, HeaderItem model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var header = await _context.HeaderItems.Where(h => !h.IsDeleted && h.Id == id).FirstOrDefaultAsync();

            if (header == null)
            {
                return NotFound();
            }

            header.Name = model.Name;
            header.Area = model.Area;
            header.Controller = model.Controller;
            header.Action = model.Action;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteHeaderItem(int id)
        {
            var headerItem = await _context.HeaderItems.Where(h => !h.IsDeleted && h.Id == id).FirstOrDefaultAsync();

            if (headerItem == null)
            {
                return NotFound();
            }

            headerItem.IsDeleted = true;
            headerItem.DeletedTime = DateTime.Now;
            headerItem.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddHeaderItem(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var headerItem = new HeaderItem
            {
                Name = model.HeaderItem.Name,
                Area = model.HeaderItem.Area,
                Controller = model.HeaderItem.Controller,
                Action = model.HeaderItem.Action,
            };

            await _context.HeaderItems.AddAsync(headerItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateMainSlider(LayoutViewModel model)
        {
            var layout = await _context.Layout.FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.MainSliderTitle = model.Layout.MainSliderTitle;
            layout.MainSliderDesc = model.Layout.MainSliderDesc;

            if (model.Layout.MainSliderImage != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.MainSliderImage));
                var fileName = await FileUtils.CopyFile(model.Layout.MainSliderImage, FileConstants.ImagePath);
                layout.MainSliderImage = fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditBlogItem(int id)
        {
            var blogItem = (await _context.LayoutBlogItems.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync());
            var model = new LayoutBlogItemViewModel
            {
                Id = blogItem.Id,
                Title = blogItem.Title,
                Text = blogItem.Text,
                Area = blogItem.Area,
                Controller = blogItem.Controller,
                Action = blogItem.Action,
                ButtonText = blogItem.ButtonText,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlogItem(int id, LayoutBlogItemViewModel model)
        {
            var blogItem = await _context.LayoutBlogItems.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync();

            if (blogItem == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            blogItem.Title = model.Title;
            blogItem.Text = model.Text;

            if (model.Image != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, blogItem.Image));
                var fileName = await FileUtils.CopyFile(model.Image, FileConstants.ImagePath);
                blogItem.Image = fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlogItem(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrEmpty(model.LayoutBlogItem.Title))
            {
                ModelState.AddModelError("Title", "Title cannot be empty!");
                return View();
            }
            if (string.IsNullOrEmpty(model.LayoutBlogItem.Text))
            {
                ModelState.AddModelError("Text", "Text cannot be empty!");
                return View();
            }
            if (string.IsNullOrEmpty(model.LayoutBlogItem.Area))
            {
                ModelState.AddModelError("Area", "Area cannot be empty!");
                return View();
            }
            if (string.IsNullOrEmpty(model.LayoutBlogItem.Controller))
            {
                ModelState.AddModelError("Controller", "Controller cannot be empty!");
                return View();
            }
            if (string.IsNullOrEmpty(model.LayoutBlogItem.Action))
            {
                ModelState.AddModelError("Action", "Action cannot be empty!");
                return View();
            }
            if (string.IsNullOrEmpty(model.LayoutBlogItem.ButtonText))
            {
                ModelState.AddModelError("ButtonText", "Button Text cannot be empty!");
                return View();
            }
            if (model.LayoutBlogItem.Image == null)
            {
                ModelState.AddModelError("Image", "Please Select Image!");
                return View();
            }

            var fileName = await FileUtils.CopyFile(model.LayoutBlogItem.Image, FileConstants.ImagePath);

            var item = new LayoutBlogItem
            {
                Title = model.LayoutBlogItem.Title,
                Text = model.LayoutBlogItem.Text,
                Area = model.LayoutBlogItem.Area,
                Controller = model.LayoutBlogItem.Controller,
                Action = model.LayoutBlogItem.Action,
                ButtonText = model.LayoutBlogItem.ButtonText,
                Image = fileName,
            };

            await _context.LayoutBlogItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlogItem(int id)
        {
            var blogItem = await _context.LayoutBlogItems.Where(b => !b.IsDeleted && b.Id == id).FirstOrDefaultAsync();

            if (blogItem == null)
            {
                return NotFound();
            }

            blogItem.IsDeleted = true;
            blogItem.DeletedTime = DateTime.Now;
            blogItem.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddFeature(int id)
        {
            var feature = await _context.Features.Where(f => !f.IsDeleted && f.Id == id).FirstOrDefaultAsync();

            if (feature == null)
            {
                return NotFound();
            }

            var layoutFeature = new LayoutFeature
            {
                Feature = feature,
            };

            await _context.LayoutFeatures.AddAsync(layoutFeature);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFeature(int id)
        {
            var layoutFeature = await _context.LayoutFeatures.Where(f => f.Id == id).FirstOrDefaultAsync();

            if (layoutFeature == null)
            {
                return NotFound();
            }

            layoutFeature.IsDeleted = true;
            layoutFeature.DeletedTime = DateTime.Now;
            layoutFeature.LastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditRoomImageSlider(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.RoomImageSliderTitle = model.Layout.RoomImageSliderTitle;
            layout.RoomImageSliderDesc = model.Layout.RoomImageSliderDesc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> EditRoomSlider(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.RoomSliderTitle = model.Layout.RoomSliderTitle;
            layout.RoomSliderDesc = model.Layout.RoomSliderDesc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditCommentSlider(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.CommentSliderTitle = model.Layout.CommentSliderTitle;
            layout.CommentSliderDesc = model.Layout.CommentSliderDesc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditFooter(LayoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var footer = await _context.Footer.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (footer == null)
            {
                return NotFound();
            }

            footer.FooterLocation = model.Footer.FooterLocation;
            footer.FooterReceptionTel = model.Footer.FooterReceptionTel;
            footer.FooterRestaurantTel = model.Footer.FooterRestaurantTel;
            footer.FooterShuttleServiceTel = model.Footer.FooterShuttleServiceTel;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditAboutPageLayout(LayoutViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.AboutBaseSliderTitle = model.Layout.AboutSection.AboutBaseSliderTitle ?? "";
            layout.AboutBaseSliderDescription = model.Layout.AboutSection.AboutBaseSliderDescription ?? "";

            if (model.Layout.AboutSection.AboutBaseSliderPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.AboutBaseSliderPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.AboutSection.AboutBaseSliderPhoto, FileConstants.ImagePath);
                layout.AboutBaseSliderPhoto = fileName;
            }

            layout.AboutCEOName = model.Layout.AboutSection.AboutCEOName ?? "";
            layout.AboutCEOText = model.Layout.AboutSection.AboutCEOText ?? "";


            if (model.Layout.AboutSection.AboutCEOPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.AboutCEOPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.AboutSection.AboutCEOPhoto, FileConstants.ImagePath);
                layout.AboutCEOPhoto = fileName;
            }

            layout.AboutFeatureTitle = model.Layout.AboutSection.AboutFeatureTitle ?? "";
            layout.AboutFeatureDescription = model.Layout.AboutSection.AboutFeatureDescription ?? "";

            layout.AboutStaffTitle = model.Layout.AboutSection.AboutStaffTitle ?? "";
            layout.AboutStaffDescription = model.Layout.AboutSection.AboutStaffDescription ?? "";

            layout.AboutVideoTitle = model.Layout.AboutSection.AboutVideoTitle ?? "";
            layout.AboutVideoDescription = model.Layout.AboutSection.AboutVideoDescription ?? "";
            layout.AboutVideoUrl = model.Layout.AboutSection.AboutVideoUrl ?? "";

            if (model.Layout.AboutSection.AboutVideoPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.AboutVideoPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.AboutSection.AboutVideoPhoto, FileConstants.ImagePath);
                layout.AboutVideoPhoto = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> EditHotelsPage(LayoutViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.HotelSliderTitle = model.Layout.HotelsMainSlider.MainSliderTitle ?? "";
            layout.HotelSliderDescription = model.Layout.HotelsMainSlider.MainSliderDescription ?? "";

            if (model.Layout.HotelsMainSlider.MainSliderPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.HotelSliderPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.HotelsMainSlider.MainSliderPhoto, FileConstants.ImagePath);
                layout.HotelSliderPhoto = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> EditRoomsPage(LayoutViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.RoomsSliderTitle = model.Layout.RoomsMainSlider.MainSliderTitle ?? "";
            layout.RoomsSliderDescription = model.Layout.RoomsMainSlider.MainSliderDescription ?? "";

            if (model.Layout.RoomsMainSlider.MainSliderPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.RoomsSliderPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.RoomsMainSlider.MainSliderPhoto, FileConstants.ImagePath);
                layout.RoomsSliderPhoto = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> EditServicesPage(LayoutViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.ServicesSliderTitle = model.Layout.ServicesMainSlider.MainSliderTitle ?? "";
            layout.ServicesSliderDescription = model.Layout.ServicesMainSlider.MainSliderDescription ?? "";

            if (model.Layout.ServicesMainSlider.MainSliderPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.ServicesSliderPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.ServicesMainSlider.MainSliderPhoto, FileConstants.ImagePath);
                layout.ServicesSliderPhoto = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> EditContactPage(LayoutViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var layout = await _context.Layout.Where(l => !l.IsDeleted).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            layout.ContactSliderTitle = model.Layout.ContactMainSlider.MainSliderTitle ?? "";
            layout.ContactSliderDescription = model.Layout.ContactMainSlider.MainSliderDescription ?? "";

            if (model.Layout.ContactMainSlider.MainSliderPhoto != null)
            {
                await FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, layout.ContactSliderPhoto));
                var fileName = await FileUtils.CopyFile(model.Layout.ContactMainSlider.MainSliderPhoto, FileConstants.ImagePath);
                layout.ContactSliderPhoto = fileName;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }

}
