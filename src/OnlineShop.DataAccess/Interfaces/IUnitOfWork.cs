using OnlineShop.DataAccess.Interfaces.AnnouncementRepo;
using OnlineShop.DataAccess.Interfaces.Categories;
using OnlineShop.DataAccess.Interfaces.SavedAds;

namespace OnlineShop.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepositoriev { get; }
        public IAnnouncementRepositorie Announcement { get; }
        public ICategoryRepositorie CategoryRepositorie { get; }
        public ISavedAdsRepositorie savedAdsRepositorie { get; }
    }
}
