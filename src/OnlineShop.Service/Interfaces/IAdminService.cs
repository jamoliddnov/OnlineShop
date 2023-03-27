using OnlineShop.Service.Services.Common.PaginationServices;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.Service.Interfaces
{
    public interface IAdminService
    {
        public Task<PageList<AnnouncementViewModel>> GetAllAsyncAdmin(int number, PaginationParams @apaginationParams);
        public Task<AnnouncementViewModel> GetByIdAsync(long id);
        public Task GetAllAsyncAdminAdd(long id);
        public Task GetAllAsyncAdminRemove(long id);

        public Task<PageList<UserViewModel>> GetAllAsyncCustomer(PaginationParams @paginationParams);

        public Task<bool> CustomerRemove(long id);
    }
}
