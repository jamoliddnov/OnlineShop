using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected AppDbContext _dbcontext;
        protected DbSet<T> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _dbcontext = context;
            _dbSet = context.Set<T>();
        }
        public virtual void Create(T entity)
        {
            _dbcontext.Add(entity);
            _dbcontext.SaveChangesAsync();
        }

        public virtual void Delete(long id)
        {
            var entiry = _dbSet.Find(id);
            _dbSet.Remove(entiry);
        }

        public Task<T?> FirstByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(long id, T entity)
        {
            throw new NotImplementedException();
        }


    }
}


//public class BaseRepository<T> : IRepository<T> where T : BaseEntity
//{
//    protected AppDbContext _dbcontext;
//    protected DbSet<T> _dbSet;
//    public BaseRepository(AppDbContext context)
//    {
//        _dbcontext = context;
//        _dbSet = context.Set<T>();
//    }
//    public virtual void Add(T entity) => _dbSet.Add(entity);

//    public virtual void Delete(long id)
//    {
//        var entity = _dbSet.Find(id);
//        if (entity is not null)
//            _dbSet.Remove(entity);
//    }

//    public virtual async Task<T?> FindByIdAsync(long id)
//    {
//        return await _dbSet.FindAsync(id);
//    }

//    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
//    {
//        return await _dbSet.FirstOrDefaultAsync(expression);
//    }

//    public virtual void Update(long id, T entity)
//    {
//        entity.Id = id;
//        _dbSet.Update(entity);
//    }
//}
