using OnlineShop.DataAccess.Interfaces.SavedAds;
using OnlineShop.Domain.Entities.SavedAds;
using OnlineShop.Service.Dtos.SavedAds;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    public class SavedAdsService : ISavedAdsService
    {
        private readonly ISavedAdsRepositorie _savedAdsRepositorie;
        public SavedAdsService(ISavedAdsRepositorie savedAdsRepositorie)
        {
            this._savedAdsRepositorie = savedAdsRepositorie;
        }

        public async Task<bool> CreateAsync(SavedAdsDto dto)
        {
            _savedAdsRepositorie.Create(dto);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _savedAdsRepositorie.Delete(id);
            return true;
        }

        public async Task<SaveAds> GetAllAsync()
        {
            var resault = _savedAdsRepositorie.GetAll();
            return (SaveAds)resault;
        }

        public async Task<SaveAds> GetByIdAsync(long id)
        {
            var resault = await _savedAdsRepositorie.FirstByIdAsync(id);
            return resault;
        }
    }
}
