using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories.Common;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.Repositories
{
    public class SavedAdsRepositorie : GenericRepositorie<SavedAd>, ISavedAdRepositorie
    {
        public SavedAdsRepositorie(AppDbContext appDbContext) :
            base(appDbContext)
        {

        }
    }
}
