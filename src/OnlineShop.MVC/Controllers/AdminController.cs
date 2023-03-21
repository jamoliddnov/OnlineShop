using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{

    [Route("admin")]
    //  [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        IAnnouncementService announcementService;

        public AdminController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("approved")]
        public async Task<IActionResult> Approved()
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.announcementService.GetAllAsyncAdmin(0);
            return View("Post", announcemts);
        }


        [HttpGet("notapproved")]
        public async Task<IActionResult> NotApproved()
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.announcementService.GetAllAsyncAdmin(1);
            return View("Post", announcemts);
        }


        [HttpGet("add")]
        public async Task<IActionResult> Add(long id)
        {
            await this.announcementService.GetAllAsyncAdminAdd(id);
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.announcementService.GetAllAsyncAdmin(1);
            return View("Post", announcemts);
        }

        [HttpGet("remove")]
        public async Task<IActionResult> Remove(long id)
        {
            await this.announcementService.GetAllAsyncAdminRemove(id);
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.announcementService.GetAllAsyncAdmin(0);
            return View("Post", announcemts);
        }
    }
}
