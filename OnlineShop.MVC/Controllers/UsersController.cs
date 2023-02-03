using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

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
        public async Task<IActionResult> Add(int page)   
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(page, 20));
            return View("userAdd", announcemts);
        }

        [HttpPost("addpostblock")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAnnouncementDto dto)
        {
            var resault = await this.announcementService.CreateAsync(dto);

            if (resault)
            {
                IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
                announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(1, 20));
                return View("userAdd", announcemts);
            }
            return View(resault);
        }

        [HttpGet("addpost")]
        public async Task<IActionResult> AddPost()

        {
            return View("userAddPost");
        }



    }
}
