using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories.Common;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.Repositories
{
	public class CategoryRepositorie : GenericRepositorie<Category>, ICategoryRepositorie
	{
		public CategoryRepositorie(AppDbContext context)
			: base(context)
		{
		}
	}
}
