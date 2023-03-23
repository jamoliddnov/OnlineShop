using AutoMapper;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.SavedAds;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services.Common.PaginationServices;

#pragma warning disable

namespace OnlineShop.Service.Services
{
    public class SavedAdsService : ISavedAdsService
    {
        private readonly ISavedAdRepositorie _savedAdsRepositorie;
        private readonly IMapper _mapper;
        public SavedAdsService(ISavedAdRepositorie savedAdsRepositorie, IMapper mapper)
        {
            this._savedAdsRepositorie = savedAdsRepositorie;
            this._mapper = mapper;
        }

        public async Task<bool> CreateAsync(SavedAdsDto dto)
        {

            var savedAds = _mapper.Map<SavedAd>(dto);
            _savedAdsRepositorie.Create(dto);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _savedAdsRepositorie.Delete(id);
            return true;
        }

        public async Task<IEnumerable<SavedAd>> GetAllAsync(PaginationParams @paginationParams)
        {
            try
            {
                var resault = await _savedAdsRepositorie.GetAllSavedAdAsync();
                return resault;
            }
            catch
            {
                return null;
            }
        }
    }
}
