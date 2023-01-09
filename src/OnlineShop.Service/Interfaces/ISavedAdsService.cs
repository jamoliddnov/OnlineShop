using OnlineShop.Domain.Entities.SavedAds;
using OnlineShop.Service.Dtos.SavedAds;

namespace OnlineShop.Service.Interfaces
{
    public interface ISavedAdsService
    {
        public Task<SaveAds> GetAllAsync();
        public Task<SaveAds> GetByIdAsync(long id);
        public Task<bool> CreateAsync(SavedAdsDto dto);
        public Task<bool> DeleteAsync(long id);
    }
}
