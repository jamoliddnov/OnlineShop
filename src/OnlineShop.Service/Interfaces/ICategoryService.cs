using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.Category;

namespace OnlineShop.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<bool> CreateAsync(CategoryDto category);
        public Task<bool> DeleteAsync(long id);
    }
}
