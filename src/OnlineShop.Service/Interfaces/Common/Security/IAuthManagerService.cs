using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces.Common.Security
{
    public interface IAuthManagerService
    {
        public string GenereteToken(User user);
    }
}
