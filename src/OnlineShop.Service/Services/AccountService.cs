using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Dtos.Account;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Interfaces.Common.Security;
using OnlineShop.Service.Services.Common.Security;
using OnlineShop.Service.ViewModels;

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

        public async Task<bool> ImageProfileAsync(AccountImageProfilDto dto)
        {
            string imagePath = await _fileService.SaveImageAsync(dto.Image);
            return true;
        }

        public async Task<(string token, string role)> LoginAsync(AccountLoginDto dto)
        {
            try
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
                if (user is null)
                {
                    return (token: "Error", role: "Error");
                }


                var hashResault = PasswordHash.Verify(dto.Password, user.PasswordHash, user.Salt);
                if (hashResault)
                {
                    GlobalVariables.Id = user.Id;
                    return (token: _authManagerService.GenereteToken(user), role: user.Role.ToString());
                }
                return (token: "Error", role: "Error");
            }
            catch
            {
                return (token: "Error", role: "Error");
            }
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto dto)
        {
            try
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
                userEntity.Role = Domain.Enums.UserRole.Admin;
                userEntity.IsEmailConfirmed = false;
                userEntity.ImagePath = "";

                _appDbContext.Users.Create(userEntity);
                var resault = await _appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return true;
            }
        }
    }
}
