using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Category;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly int _pageSize = 20;

        public CategorysController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int page)
        {
            return Ok(await _categoryService.GetAllAsync(new PaginationParams(page, _pageSize)));
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryDto dto)
        {
            return Ok(await _categoryService.CreateAsync(dto));
        }

        [HttpDelete("id"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _categoryService.DeleteAsync(id));
        }
    }
}
