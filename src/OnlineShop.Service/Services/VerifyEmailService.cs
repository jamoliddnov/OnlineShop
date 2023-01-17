using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels.User;

namespace OnlineShop.Service.Services
{
    public class VerifyEmailService : IVerifyEmailService
    {

        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        public VerifyEmailService(IEmailService emailService, IMemoryCache memoryCache)
        {

            this._emailService = emailService;
            this._cache = memoryCache;

        }

        public async Task SendCodeAsync(SendCodeToEmailViewModel email)
        {
            int code = new Random().Next(1000, 9999);

            _cache.Set(email.Email, code, TimeSpan.FromMinutes(3));

            var message = new EmailMessageViewModel()
            {
                To = email.Email,
                Subject = "Verification code",
                Body = code,
            };

            await _emailService.SendAsync(message);
        }

        //private readonly IMemoryCache _memoryCache;
        //private readonly IEmailService _emailService;
        //private readonly AppDbContext _appDbContext;
        //public VerifyEmailService(IMemoryCache memoryCache, IEmailService emailService, AppDbContext appDbContext)
        //{
        //    this._memoryCache = memoryCache;
        //    this._emailService = emailService;
        //    this._appDbContext = appDbContext;
        //}

        //public async Task SendCodeAsync(SendCodeToEmailViewModel email)
        //{
        //    int code = new Random().Next(1000, 9999);

        //    _memoryCache.Set(email.Email, code, TimeSpan.FromMinutes(3));

        //    var message = new EmailMessageViewModel()
        //    {
        //        To = email.Email,
        //        Subject = "Verification code",
        //        Body = code
        //    };

        //    await _emailService.SendAsync(message);
        //}

        //public async Task VerifyEmail(EmailVerifyViewModel emailVerify)
        //{
        //    var entity = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Email == emailVerify.Email);
        //    if (entity == null)
        //    {
        //        throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");
        //    }
        //    if (_memoryCache.TryGetValue(emailVerify.Email, out int exceptedCode))
        //    {
        //        if (exceptedCode != emailVerify.Code)
        //        {
        //            throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is wrong");
        //        }

        //        entity.IsEmailConfirmed = true;
        //        _appDbContext.Update(entity);
        //        await _appDbContext.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is expired");
        //    }
        //}

        //public async Task VerifyPasswordAsync(UserResetPasswordViewModel model)
        //{
        //    var user = await _appDbContext.Users.FirstOrDefaultAsync(p => p.Email == model.Email);

        //    if (user is null)
        //    {
        //        throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
        //    }

        //    if (_memoryCache.TryGetValue(model.Email, out int code))
        //    {
        //        if (code != model.Code)
        //        {
        //            throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is wrong");
        //        }
        //    }
        //    else
        //    {
        //        throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is expired");
        //    }

        //}
    }
}
