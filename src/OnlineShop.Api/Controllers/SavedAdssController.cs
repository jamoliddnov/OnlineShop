using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Dtos.SavedAds;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/SavedAds")]
    [ApiController]
    public class SavedAdssController : ControllerBase
    {
        private readonly ISavedAdsService _savedAdsService;
        public SavedAdssController(ISavedAdsService savedAdsService)
        {
            this._savedAdsService = savedAdsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _savedAdsService.GetAllAsync());
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _savedAdsService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] SavedAdsDto dto)
        {
            return Ok(await _savedAdsService.CreateAsync(dto));
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _savedAdsService.DeleteAsync(id));
        }
    }
}
