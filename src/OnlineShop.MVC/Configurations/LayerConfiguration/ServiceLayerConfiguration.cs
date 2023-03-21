using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.DataAccess.Repositories.Common;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Interfaces.Common;
using OnlineShop.Service.Interfaces.Common.Security;
using OnlineShop.Service.Services;
using OnlineShop.Service.Services.Common;
using OnlineShop.Service.Services.Common.Security;

namespace OnlineShop.MVC.Configurations.LayerConfiguration
{
	public static class ServiceLayerConfiguration
	{
		public static void AddService(this IServiceCollection services)
		{
			services.AddScoped<IAnnouncementService, AnnouncementService>();
			services.AddScoped<IFileService, FileService>();
			services.AddScoped<IAuthManagerService, AuthManagerService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IPaginatorService, PaginatorService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IIdentityService, IdentityService>();
			services.AddScoped<ICustomerService, CustomerService>();

		}
	}
}
