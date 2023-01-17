using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.SavedAds;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/SavedAds")]
    [ApiController]
    public class SavedAdssController : ControllerBase
    {
        private readonly ISavedAdsService _savedAdsService;
        private readonly int _pageSize = 20;
        public SavedAdssController(ISavedAdsService savedAdsService)
        {
            this._savedAdsService = savedAdsService;
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int page)
        {
            return Ok(await _savedAdsService.GetAllAsync(new PaginationParams(page, _pageSize)));
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] SavedAdsDto dto)
        {
            return Ok(await _savedAdsService.CreateAsync(dto));
        }
        [HttpDelete("id"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _savedAdsService.DeleteAsync(id));
        }
    }
}
