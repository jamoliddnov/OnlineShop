using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Service.Interfaces.Common.Security
{
    public interface IAuthManagerService
    {
        public string GenereteToken(User user);
    }
}
