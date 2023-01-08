using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/announcement")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            this._announcementService = announcementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _announcementService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAnnouncementDto createAnnouncement)
        {
            return Ok(await _announcementService.CreateAsync(createAnnouncement));
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] CreateAnnouncementDto createAnnouncement)
        {
            return Ok(await _announcementService.UpdateAsync(id, createAnnouncement));
        }
        [HttpDelete("id")]
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
