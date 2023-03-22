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
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("approved")]
        public async Task<IActionResult> Approved()
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.adminService.GetAllAsyncAdmin(0);
            return View("Post", announcemts);
        }


        [HttpGet("notapproved")]
        public async Task<IActionResult> NotApproved()
        {
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.adminService.GetAllAsyncAdmin(1);
            return View("Post", announcemts);
        }


        [HttpGet("add")]
        public async Task<IActionResult> Add(long id)
        {
            await this.adminService.GetAllAsyncAdminAdd(id);
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.adminService.GetAllAsyncAdmin(1);
            return View("Post", announcemts);
        }

        [HttpGet("remove")]
        public async Task<IActionResult> Remove(long id)
        {
            await this.adminService.GetAllAsyncAdminRemove(id);
            IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
            announcemts = await this.adminService.GetAllAsyncAdmin(1);
            return View("Post", announcemts);
        }

        [HttpGet("addPost")]
        public async Task<IActionResult> Check(int productId)
        {
            var product = await adminService.GetByIdAsync(productId);
            return View("CheckPost", product);
        }

        [HttpGet("userList")]
        public async Task<IActionResult> UserList()
        {
            var product = await adminService.GetAllAsyncCustomer();
            return View("UserList", product);
        }

        [HttpGet("removePostUser")]
        public async Task<IActionResult> removePostUser(long id)
        {
            var result = await adminService.CustomerRemove(id);

            if (result)
            {
                var product = await adminService.GetAllAsyncCustomer();
                return View("UserList", product);
            }
            return View("UserList");
        }
    }
}
