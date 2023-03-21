namespace OnlineShop.DataAccess.Interfaces.Common
{
	public interface IUnitOfWork
	{
		public IAccountRepositorie Users { get; }
		public IAnnouncementRepositorie Announcements { get; }
		public ICategoryRepositorie Categorys { get; }
		public Task<int> SaveChangesAsync();
	}
}

