﻿using OnlineShop.Domain.Entities;
using OnlineShop.Service.Services.Common.PaginationServices;

namespace OnlineShop.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllAsync(PaginationParams @paginationParams);
        public Task<bool> CreateAsync(Category category);
        public Task<bool> DeleteAsync(long id);
    }
}
