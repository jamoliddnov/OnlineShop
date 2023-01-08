using OnlineShop.DataAccess.Interfaces.Categories;
using OnlineShop.Domain.Entities.Categorys;
using OnlineShop.Service.Dtos.Category;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositorie _categoryRepositorie;
        public CategoryService(ICategoryRepositorie categoryRepositorie)
        {
            _categoryRepositorie = categoryRepositorie;
        }

        public async Task<bool> CreateAsync(CategoryDto category)
        {
            _categoryRepositorie.Create(category);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _categoryRepositorie.Delete(id);
            return true;
        }

        public async Task<Category> GetAllAsync()
        {
            var resault = _categoryRepositorie.GetAll();
            return (Category)resault;
        }
    }
}
