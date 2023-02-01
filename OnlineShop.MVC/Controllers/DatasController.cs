using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DatasController : ControllerBase
    {
        IAnnouncementService _announcementService;

        public DatasController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsyncData(int page = 1)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsync(new PaginationParams(page, 20));
            return Ok(announcemts);

        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllAsyncDataUser(int page = 1)
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await _announcementService.GetAllAsyncUser(new PaginationParams(page, 20));
            return Ok(announcemts);

        }

        [HttpGet("category")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _announcementService.GetAllCategoryAsync(id));
        }
    }
}
