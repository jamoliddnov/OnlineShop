using OnlineShop.DataAccess.DbContexts;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.Account;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Services.Common.Security;
using OnlineShop.Service.Services;

namespace OnlineShop.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> ImageProfileAsync(AccountImageProfilDto dto);

        public Task<string> LoginAsync(AccountLoginDto dto);

        public Task<bool> RegisterAsync(AccountRegisterDto dto);
  
    }
}