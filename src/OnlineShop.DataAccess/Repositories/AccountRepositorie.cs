using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories.Common;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.Repositories
{
	public class AccountRepositorie : GenericRepositorie<User>, IAccountRepositorie
	{
		public AccountRepositorie(AppDbContext context)
			: base(context)
		{
		}
	}
}


