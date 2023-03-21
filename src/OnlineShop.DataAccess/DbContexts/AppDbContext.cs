using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.DbContexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{

		}
		public virtual DbSet<User> Users { get; set; } = default!;
		public virtual DbSet<Announcement> Announcements { get; set; } = default!;
		public virtual DbSet<Category> Categorys { get; set; } = default!;
		public virtual DbSet<SavedAd> SavedAds { get; set; } = default!;
	}
}
