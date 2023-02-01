using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{
    [Route("admin")]
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.announcementService.GetAllAsyncAdmin();
            return View("Post", announcemts);
        }

        //[HttpGet("add")]
        //public async Task<IActionResult> GetAdd(long id)
        //{
        //    IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
        //    announcemts = await this.announcementService.GetAllAsyncAdminAdd();
        //    return View("Post", announcemts);
        //}
        //[HttpGet("remove")]
        //public async Task<IActionResult> GetRemove(long id)
        //{
        //    IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
        //    announcemts = await this.announcementService.GetAllAsyncAdminRemove();
        //    return View("Post", announcemts);
        //}

    }
}
