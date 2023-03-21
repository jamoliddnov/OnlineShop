using OnlineShop.Domain.Entities;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.SavedAds;

namespace OnlineShop.Service.Interfaces
{
    public interface ISavedAdsService
    {
        public Task<IEnumerable<SavedAd>> GetAllAsync(PaginationParams @paginationParams);
        public Task<bool> CreateAsync(SavedAdsDto dto);
        public Task<bool> DeleteAsync(long id);
    }
}
