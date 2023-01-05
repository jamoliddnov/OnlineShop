using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Repositories
{
    public class AccountRepositorie : IAccountRepositorie
    {
        private AppDbContext _appDbContext;

        public AccountRepositorie(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<bool> RegisterAsync(User user)
        {
            _appDbContext.Users.Add(user);
            var resault = await _appDbContext.SaveChangesAsync();
            return resault > 0;
        }
    }
}