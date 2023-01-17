using OnlineShop.Domain.Entities;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;

namespace OnlineShop.Service.Interfaces
{
    public interface IAnnouncementService
    {
        public Task<IEnumerable<Announcement>> GetAllAsync(PaginationParams @paginationParams);
        public Task<IEnumerable<Announcement>> GetAllByIdAsync(int id);
        public Task<Announcement> GetByIdAsync(long id);
        public Task<bool> CreateAsync(CreateAnnouncementDto announcements);
        public Task<bool> UpdateAsync(long id, Announcement announcement);
        public Task<bool> DeleteAsync(long id);
    }
}
