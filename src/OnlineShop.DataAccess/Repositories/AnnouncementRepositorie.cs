using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Announcements;
using OnlineShop.Domain.Entities.Announcements;

namespace OnlineShop.DataAccess.Repositories
{
    public class AnnouncementRepositorie : IAnnouncementRepositorie
    {
        private readonly AppDbContext _appDbContext;
        public AnnouncementRepositorie(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(Announcement dto)
        {
            _appDbContext.Announcements.Add(dto);
            var resault = await _appDbContext.SaveChangesAsync();
            return resault > 0;
        }

        public async Task<bool> DeleteAsync(Announcement announcement)
        {
            _appDbContext.Announcements.Remove(announcement);
            var resault = await _appDbContext.SaveChangesAsync();
            return resault > 0;
        }

        public Task<IEnumerable<Announcement>> GetAllAsync()
        {
            //var query = _appDbContext.Announcements.OrderBy(x => x.Id).AsNoTracking();
            //return query;
            throw new NotImplementedException();
        }

        public async Task<Announcement> GetByIdAsync(long id)
        {
            var resault = await _appDbContext.Announcements.FindAsync(id);
            return resault;
        }

        public async Task<bool> UpdateAsync(long id, Announcement announcement)
        {
            _appDbContext.Announcements.Update(announcement);
            var resault = await _appDbContext.SaveChangesAsync();
            return resault > 0;
        }
    }
}
