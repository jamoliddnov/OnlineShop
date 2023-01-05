using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Interfaces
{
    public interface IAccountRepositorie
    {
        public Task<bool> RegisterAsync(User user);
    }
}
