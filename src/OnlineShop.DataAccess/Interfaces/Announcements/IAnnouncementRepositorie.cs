using OnlineShop.Domain.Entities.Announcements;

namespace OnlineShop.DataAccess.Interfaces.Announcements
{
    public interface IAnnouncementRepositorie
    {
        public Task<IEnumerable<Announcement>> GetAllAsync();
        public Task<Announcement> GetByIdAsync(long id);
        public Task<bool> CreateAsync(Announcement announcement);
        public Task<bool> UpdateAsync(long id, Announcement announcement);
        public Task<bool> DeleteAsync(Announcement announcement);
    }
}
