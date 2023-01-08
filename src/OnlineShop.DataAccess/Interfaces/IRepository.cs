using OnlineShop.DataAccess.Interfaces.Common;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T?> FirstByIdAsync(long id);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        public void Create(T entity);
        public void Delete(long id);
        public void Update(long id, T entity);
    }
}