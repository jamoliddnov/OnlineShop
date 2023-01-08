using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.AnnouncementRepo;

namespace OnlineShop.DataAccess.Repositories.Announcement
{
    public class AnnouncementRepositorie : GenericRepository<OnlineShop.Domain.Entities.Announcements.Announcement>, IAnnouncementRepositorie
    {
        public AnnouncementRepositorie(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}

