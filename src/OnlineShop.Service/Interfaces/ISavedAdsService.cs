using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.SavedAds;

namespace OnlineShop.Service.Interfaces
{
    public interface ISavedAdsService
    {
        public Task<IEnumerable<SavedAd>> GetAllAsync();
        public Task<SavedAd> GetByIdAsync(long id);
        public Task<bool> CreateAsync(SavedAdsDto dto);
        public Task<bool> DeleteAsync(long id);
    }
}
