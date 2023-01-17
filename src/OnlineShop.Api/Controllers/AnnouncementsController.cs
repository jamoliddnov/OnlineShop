using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/announcement")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly int _pageSize = 20;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int page)
        {
            return Ok(await _announcementService.GetAllAsync(new PaginationParams(page, _pageSize)));
        }

        [HttpGet("idSort"), AllowAnonymous]
        public async Task<IActionResult> GetAllByIdAsync(int id)
        {
            return Ok();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAnnouncementDto createAnnouncement)
        {
            return Ok(await _announcementService.CreateAsync(createAnnouncement));
        }
        [HttpPut("id"), AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] CreateAnnouncementDto createAnnouncement)
        {
            return Ok(await _announcementService.UpdateAsync(id, createAnnouncement));
        }
        [HttpDelete("id"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _announcementService.DeleteAsync(id));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _announcementService.GetByIdAsync(id));
        }

    }
}
