using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using modpack.Models;
using modpack.ViewModels;
using modpack.Wrap;
using Microsoft.AspNetCore.SignalR;
using modpack.Service;

namespace modpack.Controllers
{
    public class AdminImageCarouselController : Controller
    {
        private readonly ModPackContext _context;
        private IWebHostEnvironment _environment;
        private readonly IHubContext<ImageCarouselHub> _hubContext;
        private readonly ILogger<AdminImageCarouselController> _logger;

        public AdminImageCarouselController(ModPackContext context, IWebHostEnvironment environment,
            IHubContext<ImageCarouselHub> hubContext, ILogger<AdminImageCarouselController> logger)
        {
            _context = context;
            _environment = environment;
            _hubContext = hubContext;
            _logger = logger;
        }

        // GET: AdminCarouselImage
        public async Task<IActionResult> List()
        {
            List<CImageCarouselViewModel> caVM = await _context.ImageCarousels
                .Select(carousel => new CImageCarouselViewModel
                {
                    aImageCarouselID = carousel.ImageCarouselId,
                    aImageFile = carousel.Image,
                    aImageDescription = carousel.Description
                })
                .ToListAsync();
            return View(caVM);
        }

        // GET: AdminCarouselImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageCarousel = await _context.ImageCarousels
                .FirstOrDefaultAsync(m => m.ImageCarouselId == id);
            if (imageCarousel == null)
            {
                return NotFound();
            }

            return View(imageCarousel);
        }

        // GET: AdminCarouselImage/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: AdminCarouselImage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CImageCarouselViewModel iVM)
        {
            if (iVM.photo == null || iVM.photo.Length == 0)
            {
                ModelState.AddModelError("photo", "尚未選擇圖片");
                return View(iVM);
            }
            if (iVM.aImageDescription == null || iVM.aImageDescription.Length == 0)
            {
                ModelState.AddModelError("aImageDescription", "尚未輸入相關文字");
                return View(iVM);
            }

            string photoName = "carousel" + Guid.NewGuid().ToString().Substring(0, 3) + ".jpeg";
            //string photoName = "carousel" + newImage.ImageCarouselId.ToString() + ".jpeg";
            using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/carousel", photoName), FileMode.Create))
            {
                await iVM.photo.CopyToAsync(fileStream);
            }
            //newImage.Image = photoName;

            ImageCarousel newImage = new ImageCarousel
            {
                Image = photoName,
                Description = iVM.aImageDescription
            };

            _context.Add(newImage);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // GET: AdminCarouselImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var im = await _context.ImageCarousels.FindAsync(id);
            var vm = new CImageCarouselViewModel
            {
                aImageCarouselID = im.ImageCarouselId,
                aImageFile = im.Image,
                aImageDescription = im.Description
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CImageCarouselViewModel iVM)
        {
            int imageCarouselId = iVM.aImageCarouselID;
            ImageCarousel icEdit = await _context.ImageCarousels.FindAsync(iVM.aImageCarouselID);
            if (icEdit != null)
            {
                if (iVM.photo != null)
                {
                    string photoName = "carousel" + Guid.NewGuid().ToString().Substring(0, 5) + ".jpeg";
                    //string photoName = "carousel" + imageCarouselId.ToString() + ".jpeg";
                    icEdit.Image = photoName;
                    using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images/carousel", photoName), FileMode.Create))
                    {
                        await iVM.photo.CopyToAsync(fileStream);
                    }
                }
                icEdit.Description = iVM.aImageDescription;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var imageCarousel = await _context.ImageCarousels
                .FirstOrDefaultAsync(m => m.ImageCarouselId == id);
            if (imageCarousel == null)
            {
                return NotFound();
            }

            var cWAdmin = new CWrapAdministrator
            {
                ImageCarouselID = imageCarousel.ImageCarouselId,
                ImageFile = imageCarousel.Image,
                Description = imageCarousel.Description
            };

            return View(cWAdmin);
        }

        // POST: AdminCarouselImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageCarousel = await _context.ImageCarousels.FindAsync(id);
            if (imageCarousel != null)
            {
                _context.ImageCarousels.Remove(imageCarousel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // GET: /images/{ids}
        [HttpGet("AdminImageCarousel/images")]
        public IActionResult GetImage([FromQuery] string ids)
        {
            try
            {
                var idArray = ids.Split(',').Select(id => int.Parse(id)).ToList();
                var imagePaths = new List<string>();
                foreach (var id in idArray)
                {
                    var imagePath = $"/images/carousel/carousel{id}.jpeg";
                    imagePaths.Add(imagePath);
                }

                // 发送更新到所有客户端
                _hubContext.Clients.All.SendAsync("ReceiveImagePaths", imagePaths);

                return Ok(imagePaths);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"找不到圖片: {ex.Message}");
            }
        }

        // GET: /imagesTwo/{ids}
        [HttpGet("AdminImageCarousel/imagesTwo")]
        public async Task<IActionResult> GetImageTwo([FromQuery] string ids)
        {
            try
            {
                var idArray = ids.Split(',').Select(id => int.Parse(id)).ToList();
                var productList = await _context.Products
                    .Include(p => p.Status)
                    .Include(p => p.Promotion)
                    .Where(p => idArray.Contains(p.ProductId))
                    .Take(2)
                    .Select(p => new Product
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Category = p.Category,
                        ImageFileName = p.ImageFileName,
                        StatusId = p.StatusId,
                        PromotionId = p.PromotionId,
                        Promotion = p.Promotion,
                        OriginalPrice = p.OriginalPrice,
                        SalePrice = p.SalePrice,
                    })
                    .ToListAsync();

                return Ok(JsonSerializer.Serialize(productList));
                //return Json(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"找不到圖片: {ex.Message}");
            }
        }

        private bool ImageCarouselExists(int id)
        {
            return _context.ImageCarousels.Any(e => e.ImageCarouselId == id);
        }
    }
}
