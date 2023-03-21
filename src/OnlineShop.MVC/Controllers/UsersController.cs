using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{

	[Route("users")]
	// [Authorize(Roles = "User")]
	[AllowAnonymous]
	public class UsersController : Controller
	{
		IAnnouncementService announcementService;
		public UsersController(IAnnouncementService announcementService)
		{
			this.announcementService = announcementService;
		}

		public async Task<ViewResult> Active()
		{
			IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
			announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(1, 20));
			return View("userAdd", announcemts);
		}

		[HttpGet("active")]
		public async Task<IActionResult> Active2(int page = 1)
		{
			IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
			announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(page, 20));
			return View("userAdd", announcemts);
		}

		[HttpGet("notActive")]
		public async Task<IActionResult> NorActive(int page)
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
