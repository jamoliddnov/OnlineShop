using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Interfaces.Common
{
    public interface IGenericRepositorie<T> : IRepositorie<T> where T : BaseEntity
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}

