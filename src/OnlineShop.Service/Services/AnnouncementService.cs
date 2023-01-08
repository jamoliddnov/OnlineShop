using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.AnnouncementRepo;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    internal class AnnouncementService : IAnnouncementService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAnnouncementRepositorie _announcementRepositorie;
        public AnnouncementService(AppDbContext appDbContext, IAnnouncementRepositorie announcementRepositorie)
        {
            _appDbContext = appDbContext;
            _announcementRepositorie = announcementRepositorie;

        }

        public async Task<bool> CreateAsync(Domain.Entities.Announcements.Announcement announcement)
        {
            announcement.CreateAt = DateTime.UtcNow;
            announcement.UserId = 1;

            _announcementRepositorie.Create(announcement);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            _announcementRepositorie.Delete(id);
            return true;

        }

        public async Task<Domain.Entities.Announcements.Announcement> GetAllAsync()
        {
            var resault = _announcementRepositorie.GetAll();
            return (Domain.Entities.Announcements.Announcement)resault;
        }

        public async Task<Domain.Entities.Announcements.Announcement> GetByIdAsync(long id)
        {
            var resault = await _announcementRepositorie.FirstByIdAsync(id);
            return resault;
        }

        public async Task<bool> UpdateAsync(long id, Domain.Entities.Announcements.Announcement announcement)
        {
            _announcementRepositorie.Update(id, announcement);
            return true;
        }
    }
}
