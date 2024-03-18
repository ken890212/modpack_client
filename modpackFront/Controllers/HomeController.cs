using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using modpackFront.DTO;
using modpackFront.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace modpackFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModPackContext _context;
        private readonly ILogger<HomeController> _logger;

		public HomeController(ModPackContext modPackContext, ILogger<HomeController> logger)
        {
            _context = modPackContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var imageCarousels = _context.ImageCarousels.ToList();
            var product = _context.Products
                .Include(p => p.Status)
                .Include(p => p.Promotion)
                .ToList();

            var homeDTO = new HomeDTO
            {
                ImageCarousel = imageCarousels,
                Product = product,
            };
            ViewData["CustomerId"] = User.Identity.IsAuthenticated ? User.Identity.Name : "Guest";

            return View(homeDTO);
        }

        public IActionResult exampleHome()
        {
            var imageCarousels = _context.ImageCarousels.ToList();
            return View(imageCarousels);
        }

        [HttpPost]
        public IActionResult AddToFavorites(int? productId, int? InspirationId, int? CustomizedId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int? productId, int? InspirationId, int? CustomizedId)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ReachOut()
        {
            return View();
        }

        //接收聯絡我們資料的action ??
        //public IActionResult aReachOut(接收資料)---------------------------------------------------------------------



        public IActionResult Sendout()
        {
            return View();
        }

        //------------------------------------------------------------------------------------------------------------
        [HttpPost]
       
        public IActionResult Sendout(ServiceRecord record)
        {
                _context.ServiceRecords.Add(record);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        //-----------------------------------------------------------------------------------------------------------


        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult GoBlog()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult StoreLocations() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
