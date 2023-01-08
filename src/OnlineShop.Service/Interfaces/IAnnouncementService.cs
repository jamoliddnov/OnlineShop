using OnlineShop.Domain.Entities.Announcements;

namespace OnlineShop.Service.Interfaces
{
    public interface IAnnouncementService
    {
        public Task<Announcement> GetAllAsync();
        public Task<Announcement> GetByIdAsync(long id);
        public Task<bool> CreateAsync(Announcement announcement);
        public Task<bool> UpdateAsync(long id, Announcement announcement);
        public Task<bool> DeleteAsync(long id);
    }
}
