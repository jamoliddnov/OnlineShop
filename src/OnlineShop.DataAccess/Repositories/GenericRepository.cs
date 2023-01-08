using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Repositories
{
    public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
        where T : BaseEntity
    {
        public GenericRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<T> GetAll() => _dbSet;

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);
    }
}
