using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Common;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Repositories.Common
{
    public class BaseRepositorie<T> : IRepositorie<T> where T : BaseEntity
    {
        protected AppDbContext _dbcontext;
        protected DbSet<T> _dbSet;

        public BaseRepositorie(AppDbContext context)
        {
            _dbcontext = context;
            _dbSet = context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);

            }
            catch
            {

            }

        }

        public virtual async Task<T?> FindByIdAsync(long id)
        {

            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public virtual async void Delete(long id)
        {
            var entiry = _dbSet.Find(id);
            if (entiry is not null)
            {
                _dbSet.Remove(entiry);
            }
        }


        public virtual void Update(long id, T entity)
        {
            try
            {
                entity.Id = id;
                _dbSet.Update(entity);
            }
            catch
            {

            }

        }

        public virtual async Task<T?> FirstByIdAsync(long id)
        {

            return await _dbSet.FindAsync(id);
        }
    }
}


