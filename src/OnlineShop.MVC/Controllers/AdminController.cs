using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Helpers;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services.Common.PaginationServices;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{

    [Route("admin")]
    //  [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly int _pageSize = 20;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("approved")]
        public async Task<IActionResult> Approved(int number, int page)
        {
            GlobalVariables.CategoryId = 1;
            var announcemts = await this.adminService.GetAllAsyncAdmin(number, new PaginationParams(page, _pageSize));
            return View("Post", announcemts);
        }


        [HttpGet("notapprovedd")]
        public async Task<IActionResult> NotApprovedd()
        {
            long id = HttpContextHelper.UserId;
            var res = HttpContextHelper.UserRole;
            GlobalVariables.CategoryId = 0;
            var announcemts = await adminService.GetAllAsyncAdmin(0, new PaginationParams(1, _pageSize));
            return View("Post", announcemts);
        }

        [HttpGet("notapproved")]
        public async Task<IActionResult> NotApproved(int number, int page)
        {
            GlobalVariables.CategoryId = 1;
            var announcemts = await adminService.GetAllAsyncAdmin(number, new PaginationParams(page, _pageSize));
            return View("Post", announcemts);
        }


        [HttpGet("add")]
        public async Task<IActionResult> Add(long id)
        {
            await this.adminService.GetAllAsyncAdminAdd(id);

            if (GlobalVariables.CategoryId == 1)
            {
                var announcemts = await adminService.GetAllAsyncAdmin(1, new PaginationParams(1, _pageSize));
                return View("Post", announcemts);
            }
            var announcemt = await adminService.GetAllAsyncAdmin(0, new PaginationParams(1, _pageSize));
            return View("Post", announcemt);
        }

        [HttpGet("remove")]
        public async Task<IActionResult> Remove(long id, int page)
        {
            await this.adminService.GetAllAsyncAdminRemove(id);

            if (GlobalVariables.CategoryId == 1)
            {
                var announcemts = await adminService.GetAllAsyncAdmin(1, new PaginationParams(1, _pageSize));
                return View("Post", announcemts);
            }
            var announcemt = await adminService.GetAllAsyncAdmin(0, new PaginationParams(1, _pageSize));
            return View("Post", announcemt);
        }

        [HttpGet("addPost")]
        public async Task<IActionResult> Check(int productId)
        {
            var product = await adminService.GetByIdAsync(productId);
            return View("CheckPost", product);
        }

        [HttpGet("userList")]
        public async Task<IActionResult> UserList(int page)
        {
            var product = await this.adminService.GetAllAsyncCustomer(new PaginationParams(page, _pageSize));
            return View("UserList", product);
        }

        [HttpGet("removePostUser")]
        public async Task<IActionResult> removePostUser(long id)
        {
            var result = await adminService.CustomerRemove(id);

            if (result)
            {
                var product = await adminService.GetAllAsyncCustomer(new PaginationParams(1, _pageSize));
                return View("UserList", product);
            }
            return View("UserList");
        }
    }
}
