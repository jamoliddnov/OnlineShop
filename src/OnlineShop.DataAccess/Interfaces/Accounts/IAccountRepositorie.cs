using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.DataAccess.Interfaces
{
    public interface IAccountRepositorie
    {
        public Task<bool> RegisterAsync(User user);
    }
}
