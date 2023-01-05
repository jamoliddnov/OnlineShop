using OnlineShop.DataAccess.DbContexts;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _appDbContext;
        public AccountService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<string> LoginAsync(AccountLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(AccountRegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
//private readonly AppDbContext _appDbContext;
//private readonly IFileService _fileService;
//private readonly IAuthManager _authManager;

//public AccountService(AppDbContext appDbContext, IFileService fileService, IAuthManager authManager)
//{
//    _appDbContext = appDbContext;
//    _fileService = fileService;
//    _authManager = authManager;
//}

//public async Task<string> LoginAsync(AccountLoginDto dto)
//{
//    var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
//    if (user is null)
//    {
//        throw new StatusCodeException(HttpStatusCode.NotFound, "Email not found");
//    }

//    var hashResault = PasswordHasher.Verify(dto.Password, user.PasswordHash, user.Salt);
//    if (hashResault)
//    {
//        return _authManager.GenereteToken(user);
//    }
//    else
//    {
//        throw new StatusCodeException(HttpStatusCode.BadRequest, "Passoword in invalid");
//    }
//}



//public async Task<bool> RegisterAsync(AccountRegisterDto dto)
//{
//    var emailUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
//    if (emailUser is not null)
//    {
//        throw new StatusCodeException(HttpStatusCode.Conflict, "Email is already exists");
//    }
//    var hashResault = PasswordHasher.Hash(dto.Password);
//    var userEntity = (User)dto;
//    userEntity.PasswordHash = hashResault.Hash;
//    userEntity.Salt = hashResault.Salt;
//    userEntity.Role = Enums.UserRole.User;
//    if (dto.Image is not null)
//    {
//        userEntity.ImagePath = await _fileService.SaveImageAsync(dto.Image);
//    }
//    _appDbContext.Users.Add(userEntity);
//    var resault = await _appDbContext.SaveChangesAsync();
//    return resault > 0;
//}
