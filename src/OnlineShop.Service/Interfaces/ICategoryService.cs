using OnlineShop.Domain.Entities.Categorys;
using OnlineShop.Service.Dtos.Category;

namespace OnlineShop.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<Category> GetAllAsync();
        public Task<bool> CreateAsync(CategoryDto category);
        public Task<bool> DeleteAsync(long id);
    }
}
