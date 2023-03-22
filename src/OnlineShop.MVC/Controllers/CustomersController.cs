﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{

	[Route("user")]
	// [Authorize(Roles = "User")]
	[AllowAnonymous]
	public class CustomersController : Controller
	{
		IAnnouncementService announcementService;
		ICustomerService customerService;
		public CustomersController(IAnnouncementService announcementService, ICustomerService customerService)
		{
			this.announcementService = announcementService;
			this.customerService = customerService;
		}

		public async Task<ViewResult> Active()
		{
			IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
			announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(1, 20));
			return View("CustomerAdd", announcemts);
		}

		[HttpGet("active")]
		public async Task<IActionResult> Active2(int page = 1)
		{
			IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
			announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(page, 20));
			return View("CustomerAdd", announcemts);
		}

		[HttpGet("notActive")]
		public async Task<IActionResult> NotActive(int page)
		{
			IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
			announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(page, 20));
			return View("CustomerAdd", announcemts);
		}

		[HttpPost("addpostblock")]
		public async Task<IActionResult> CreateAsync([FromForm] CreateAnnouncementDto dto)
		{
			var resault = await this.announcementService.CreateAsync(dto);

			if (resault)
			{
				IList<AnnouncementViewModel> announcemts = new List<AnnouncementViewModel>();
				announcemts = await announcementService.GetAllAsyncUser(new PaginationParams(1, 20));
				return View("CustomerAdd", announcemts);
			}
			return View(resault);
		}

		[HttpGet("addpost")]
		public async Task<IActionResult> AddPost()

		{
			return View("CustomerAddPost");
		}

		[HttpGet("idPost")]
		public async Task<IActionResult> GetByIdPost(int productId)
		{
			var product = await customerService.GetByIdAsync(productId);
			return View("CustomerAnnouncementId", product);
		}

		[HttpGet("updatePost")]
		public async Task<IActionResult> UpdatePost(int productId)
		{
			var product = await customerService.GetByIdAsync(productId);
			return View("CustomerUpdatePost", product);
		}

		[HttpPost("updatePostBlock")]
		public async Task<IActionResult> UpdatePost([FromForm] CustomerAnnouncementViewModel dto)
		{
			var result = await customerService.UpdateAsync(dto);
			if (result > 0)
			{
				var product = await customerService.GetByIdAsync((int)result);
				return View("CustomerAnnouncementId", product);
			}
			return View("CustomerUpdatePost", dto);
		}
	}
}