using Microsoft.AspNetCore.Mvc;
using OnlineShop.MVC.Models;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services.Common.PaginationServices;
using OnlineShop.Service.ViewModels;
using System.Diagnostics;

namespace OnlineShop.MVC.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        IAnnouncementService announcementService;

        public ILogger<HomeController> Logger => _logger;

        public HomeController(ILogger<HomeController> logger, IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
            _logger = logger;
        }



        public async Task<IActionResult> Index(int page = 1)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await announcementService.GetAllAsync(new PaginationParams(page, 20));
            return View("../Announcements/Announcement", announcemts);
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search(int page = 1)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await announcementService.GetAllAsync(new PaginationParams(page, 20));
            return View("Index", announcemts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}