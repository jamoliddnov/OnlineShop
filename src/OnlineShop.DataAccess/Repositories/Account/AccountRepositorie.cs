using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.Domain.Entities.Users;

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


