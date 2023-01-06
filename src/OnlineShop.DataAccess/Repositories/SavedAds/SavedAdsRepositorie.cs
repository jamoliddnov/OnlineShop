using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.SavedAds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Repositories.SavedAds
{
    public class SavedAdsRepositorie : GenericRepository<OnlineShop.Domain.Entities.SavedAds.SaveAds>, ISavedAdsRepositorie  
    {
        public SavedAdsRepositorie(AppDbContext appDbContext):
            base(appDbContext)
        {

        }
    }
}
