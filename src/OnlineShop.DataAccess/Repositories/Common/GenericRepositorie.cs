using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Common;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Repositories.Common
{
	public class GenericRepositorie<T> : BaseRepositorie<T>, IGenericRepositorie<T>
		where T : BaseEntity
	{
		public GenericRepositorie(AppDbContext context) : base(context)
		{
		}

		public IQueryable<T> GetAll() => _dbSet;

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
			=> _dbSet.Where(expression);
	}
}
