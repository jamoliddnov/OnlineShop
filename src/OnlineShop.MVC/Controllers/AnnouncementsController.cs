using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services.Common.PaginationServices;
using OnlineShop.Service.ViewModels;


namespace OnlineShop.MVC.Controllers
{
    [AllowAnonymous]
    [Route("announcement")]
    public class AnnouncementsController : Controller
    {
        IAnnouncementService _announcementService;
        private readonly int _pageSize = 20;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync(int page = 1)
        {

            var announcemts = await _announcementService.GetAllAsync(new PaginationParams(page, _pageSize));
            return View("../Announcements/Announcement", announcemts);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetAllAsyncCategory(int category)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllCategoryAsync(category, new PaginationParams(1, _pageSize));
            return View("../Announcements/Announcement", announcemts);
        }

        [HttpGet("{announcementId}")]
        public async Task<IActionResult> GetAsync(int productId)
        {
            IList<AnnouncementViewModel> product = new List<AnnouncementViewModel>();
            product = await _announcementService.GetByIdAsync(productId);
            return View("AnnouncementId", product);
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search(string search)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsyncSearch(search, new PaginationParams(1, _pageSize));
            return View("../Announcements/Announcement", announcemts);
        }


        [HttpGet("save")]
        public async Task<IActionResult> Save(int productId)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsync(new PaginationParams(1, _pageSize));
            return View("../Home/Index", announcemts);
        }
    }
}
