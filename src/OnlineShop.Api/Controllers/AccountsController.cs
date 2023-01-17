using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Dtos.Account;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels.User;

namespace OnlineShop.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IVerifyEmailService _emailService;


        public AccountsController(IAccountService accountService, IVerifyEmailService emailService)
        {
            this._accountService = accountService;
            this._emailService = emailService;
        }
        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromForm] AccountRegisterDto dto)
        {
            var resault = await _accountService.RegisterAsync(dto);
            return Ok(resault);
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] AccountLoginDto dto)
        {
            var resault = await _accountService.LoginAsync(dto);
            return Ok(resault);
        }

        [HttpPost("image"), Authorize(Roles = "User")]
        public async Task<IActionResult> ImageAddUserProfil([FromForm] AccountImageProfilDto dto)
        {
            return Ok(await _accountService.ImageProfileAsync(dto));
        }

        [HttpPost("send-code-to-email")]
        public async Task<IActionResult> SendToEmail([FromForm] SendCodeToEmailViewModel email)
        {
            return Ok(_emailService.SendCodeAsync(email));
        }
    }
}
