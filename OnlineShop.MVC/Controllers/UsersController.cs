using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.MVC.Controllers
{
    [Route("user")]
    public class UsersController : Controller
    {
        IAnnouncementService announcementService;
        public UsersController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add()
        {
            return View("userAdd");
        }

        [HttpGet("addpost")]
        public async Task<IActionResult> AddPost()
        {
            return View("userAddpost");
        }

        [HttpPost("addpostblock")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAnnouncementDto dto)
        {
            var resault = await this.announcementService.CreateAsync(dto);
            if (resault)
            {
                return View("userAdd");
            }
            return View(resault);
        }
    }
}
