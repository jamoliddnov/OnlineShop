using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories.Common;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.Repositories
{
	public class AnnouncementRepositorie : GenericRepositorie<Announcement>, IAnnouncementRepositorie
	{
		public AnnouncementRepositorie(AppDbContext appDbContext)
			: base(appDbContext)
		{
		}
	}
}

