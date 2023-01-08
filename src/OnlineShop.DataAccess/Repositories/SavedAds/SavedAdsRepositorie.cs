using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.SavedAds;

namespace OnlineShop.DataAccess.Repositories.SavedAds
{
    public class SavedAdsRepositorie : GenericRepository<OnlineShop.Domain.Entities.SavedAds.SaveAds>, ISavedAdsRepositorie
    {
        public SavedAdsRepositorie(AppDbContext appDbContext) :
            base(appDbContext)
        {

        }
    }
}
