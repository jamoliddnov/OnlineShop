using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories;
using OnlineShop.Domain.Entities.Users;
using System.Linq.Expressions;

namespace OnlineShop.DataAccess.Repositories.Account
{
    public class AccountRepositorie : GenericRepository<User>, IAccountRepository
    {
        public AccountRepositorie(AppDbContext context) 
            : base(context)
        {
        }
    }
}


