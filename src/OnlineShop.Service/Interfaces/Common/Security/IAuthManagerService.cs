using OnlineShop.Domain.Entities;

namespace OnlineShop.Service.Interfaces.Common.Security
{
    public interface IAuthManagerService
    {
        public string GenereteToken(User user);
    }
}
