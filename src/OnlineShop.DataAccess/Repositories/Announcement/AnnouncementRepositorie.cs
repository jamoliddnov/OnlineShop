using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.AnnouncementRepo;
using OnlineShop.Domain.Entities.Announcements;
using System.Linq.Expressions;

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

