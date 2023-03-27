using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Services.Common.PaginationServices;
using OnlineShop.Service.ViewModels;


namespace OnlineShop.Service.Interfaces
{
    public interface IAnnouncementService
    {
        public Task<PageList<AnnouncementViewModel>> GetAllAsync(PaginationParams @paginationParams);
        public Task<PageList<AnnouncementViewModel>> GetAllAsyncUser(int page, PaginationParams @paginationParams);
        public Task<PageList<AnnouncementViewModel>> GetAllCategoryAsync(int id, PaginationParams @paginationParams);
        public Task<bool> CreateAsync(CreateAnnouncementDto announcements);
        public Task<bool> UpdateAsync(long id, Announcement announcement);
        public Task<bool> DeleteAsync(long id);
        public Task<IList<AnnouncementViewModel>> GetByIdAsync(long id);
        public Task<PageList<AnnouncementViewModel>> GetAllAsyncSearch(string serach, PaginationParams @paginationParams);
    }
}
