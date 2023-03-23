using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.SavedAds;
using OnlineShop.Service.Services.Common.PaginationServices;

namespace OnlineShop.Service.Interfaces
{
    public interface ISavedAdsService
    {
        public Task<IEnumerable<SavedAd>> GetAllAsync(PaginationParams @paginationParams);
        public Task<bool> CreateAsync(SavedAdsDto dto);
        public Task<bool> DeleteAsync(long id);
    }
}
