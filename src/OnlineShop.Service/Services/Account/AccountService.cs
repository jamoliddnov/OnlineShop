using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Interfaces.Accounts;
using OnlineShop.Service.Interfaces.Common.Security;
using OnlineShop.Service.Services.Common.Security;

namespace OnlineShop.Service.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;
        private readonly IAuthManagerService _authManagerService;
        private readonly IAccountRepositorie _accountRepositorie;
        public AccountService(AppDbContext appDbContext, IFileService fileService, IAuthManagerService authManagerService, IAccountRepositorie accountRepositorie)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
            _authManagerService = authManagerService;
            _accountRepositorie = accountRepositorie;
        }
        public async Task<string> LoginAsync(AccountLoginDto dto)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user is null)
            {
                return "Email not found";
            }

            var hashResault = PasswordHash.Verify(dto.Password, user.PasswordHash, user.Salt);
            if (hashResault)
            {
                return _authManagerService.GenereteToken(user);
            }
            return "Error";
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto dto)
        {
            var emailUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (emailUser is not null)
            {
                return false;
            }
            var hashResault = PasswordHash.Hash(dto.Password);
            var userEntity = (User)dto;
            userEntity.PasswordHash = hashResault.Hash;
            userEntity.Salt = hashResault.Salt;
            userEntity.Role = Domain.Enums.UserRole.User;
            userEntity.ImagePath = "";

            var resault = await _accountRepositorie.RegisterAsync(userEntity);
            return resault;
        }
    }
}
