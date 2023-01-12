using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Interfaces.Common.Security;
using OnlineShop.Service.Services.Common.Security;

namespace OnlineShop.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IFileService _fileService;
        private readonly IAuthManagerService _authManagerService;
        private readonly IUnitOfWork _appDbContext;
        public AccountService(IFileService fileService, IAuthManagerService authManagerService, IUnitOfWork appDbContext)
        {

            _fileService = fileService;
            _authManagerService = authManagerService;
            _appDbContext = appDbContext;
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

            _appDbContext.Users.Create(userEntity);
            var resault = await _appDbContext.SaveChangesAsync();
            return resault > 0;
        }
    }
}
