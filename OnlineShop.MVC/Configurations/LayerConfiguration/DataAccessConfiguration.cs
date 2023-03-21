using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.DataAccess.Repositories.Common;

namespace OnlineShop.MVC.Configurations.LayerConfiguration
{
	public static class DataAccessConfiguration
	{
		public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DatabaseConnection");
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}


