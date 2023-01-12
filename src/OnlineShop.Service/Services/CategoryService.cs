using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.Category;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _repository;
        public CategoryService(IUnitOfWork repository)
        {
            this._repository = repository;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            _repository.Categorys.Create(category);
            _repository.SaveChangesAsync();
            return true;
        }

        public Task<bool> CreateAsync(CategoryDto category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _repository.Categorys.Delete(id);
            _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var resault = _repository.Categorys.GetAll();
            return resault;
        }

    }
}
