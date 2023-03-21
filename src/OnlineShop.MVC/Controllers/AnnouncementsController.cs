using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{
    [AllowAnonymous]
    [Route("announcement")]
    public class AnnouncementsController : Controller
    {
        IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync(int page = 1)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsync(new PaginationParams(page, 20));
            return View("../Announcements/Announcement", announcemts);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetAllAsyncCategory(int page)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllCategoryAsync(page);
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
            announcemts = await _announcementService.GetAllAsyncSearch(search);
            return View("../Announcements/Announcement", announcemts);
        }


        [HttpGet("save")]
        public async Task<IActionResult> Save(int productId)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsync(new PaginationParams(1, 20));
            return View("../Home/Index", announcemts);
        }
    }
}
