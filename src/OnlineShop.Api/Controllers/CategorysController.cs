using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Dtos.Category;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategorysController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryDto dto)
        {
            return Ok(await _categoryService.CreateAsync(dto));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _categoryService.DeleteAsync(id));
        }
    }
}
