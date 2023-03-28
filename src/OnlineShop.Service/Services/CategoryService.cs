using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services.Common.PaginationServices;

#pragma warning disable

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
            try
            {
                _repository.Categorys.Create(category);
                var res = await _repository.SaveChangesAsync();
                return res > 0;
            }
            catch
            {
                return true;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _repository.Categorys.Delete(id);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(PaginationParams @paginationParams)
        {
            var resault = _repository.Categorys.GetAll();
            return resault;
        }

    }
}
