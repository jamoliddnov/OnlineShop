using OnlineShop.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<string> LoginAsync(AccountLoginDto dto);
        public Task<bool> RegisterAsync(AccountRegisterDto dto);
    }
}

