using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;

namespace OnlineShop.DataAccess.Repositories.Common
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _appDbContext;

		public IAccountRepositorie Users { get; }

		public IAnnouncementRepositorie Announcements { get; }

		public ICategoryRepositorie Categorys { get; }



		public UnitOfWork(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
			Users = new AccountRepositorie(appDbContext);
			Announcements = new AnnouncementRepositorie(appDbContext);
			Categorys = new CategoryRepositorie(appDbContext);

		}

		public async Task<int> SaveChangesAsync()
		{
			try
			{
				return await _appDbContext.SaveChangesAsync();
			}
			catch
			{
				return 0;
			}
		}
	}
}






