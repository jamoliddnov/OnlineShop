using OnlineShop.Domain.Entities;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.Service.Interfaces
{
    public interface IAnnouncementService
    {
        public Task<IList<AnnouncementViewModel>> GetAllAsync(PaginationParams @paginationParams);
        public Task<IList<AnnouncementViewModel>> GetAllAsyncUser(PaginationParams @paginationParams);
        public Task<IList<AnnouncementViewModel>> GetAllCategoryAsync(int id);
        public Task<bool> CreateAsync(CreateAnnouncementDto announcements);
        public Task<bool> UpdateAsync(long id, Announcement announcement);
        public Task<bool> DeleteAsync(long id);
        public Task<IList<AnnouncementViewModel>> GetByIdAsync(long id);
        public Task<IList<AnnouncementViewModel>> GetAllAsyncAdmin();
        public Task GetAllAsyncAdminAdd(long id);
        public Task GetAllAsyncAdminRemove(long id);
    }
}
