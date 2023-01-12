using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.DataAccess.Repositories;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.SavedAds;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    public class SavedAdsService : ISavedAdsService
    {
        private readonly IUnitOfWork _savedAdsRepositorie;
        public SavedAdsService(IUnitOfWork savedAdsRepositorie)
        {
            this._savedAdsRepositorie = savedAdsRepositorie;
        }

        public async Task<bool> CreateAsync(SavedAdsDto dto)
        {
            _savedAdsRepositorie.SavedAds.Create(dto);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _savedAdsRepositorie.SavedAds.Delete(id);
            return true;
        }

        public async Task<IEnumerable<SavedAd>> GetAllAsync()
        {
            var resault = _savedAdsRepositorie.SavedAds.GetAll();
            return resault;
        }

        public async Task<SavedAd> GetByIdAsync(long id)
        {
            var resault = await _savedAdsRepositorie.SavedAds.FirstByIdAsync(id);
            return resault;
        }


    }
}
