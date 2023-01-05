using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Entities.Announcements;
using OnlineShop.Domain.Entities.Categorys;
using OnlineShop.Domain.Entities.SavedAds;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Categorie> Categories { get; set; } = default!;
        public virtual DbSet<SaveAds> SaveAds { get; set; } = default!;
    }
}
