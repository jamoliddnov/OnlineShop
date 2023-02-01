using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{
    [Route("announcement")]
    public class AnnouncementsController : Controller
    {
        IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int page = 1)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsync(new PaginationParams(page, 20));
            return View("Announcement", announcemts);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetAllAsyncCategory(int page)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllCategoryAsync(page);
            return View("Announcement", announcemts);
        }

        [HttpGet("{announcementId}")]
        public async Task<IActionResult> GetAsync(int productId)
        {
            IList<AnnouncementViewModel> product = new List<AnnouncementViewModel>();
            product = await _announcementService.GetByIdAsync(productId);
            return View("AnnouncementId", product);
        }
    }
}
