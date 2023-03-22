using OnlineShop.Service.ViewModels;

namespace OnlineShop.Service.Interfaces
{
    public interface IAdminService
    {
        public Task<IList<AnnouncementViewModel>> GetAllAsyncAdmin(int number);
        public Task<AnnouncementViewModel> GetByIdAsync(long id);
        public Task GetAllAsyncAdminAdd(long id);
        public Task GetAllAsyncAdminRemove(long id);

        public Task<IList<UserViewModel>> GetAllAsyncCustomer();

        public Task<bool> CustomerRemove(long id);
    }
}
