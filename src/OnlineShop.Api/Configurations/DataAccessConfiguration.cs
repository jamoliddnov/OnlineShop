using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.DataAccess.Repositories.Common;

namespace OnlineShop.Api.Configurations
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
