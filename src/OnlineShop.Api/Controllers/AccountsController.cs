using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] AccountRegisterDto dto)
        {
            var resault = await _accountService.RegisterAsync(dto);
            return Ok(resault);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] AccountLoginDto dto)
        {
            var resault = await _accountService.LoginAsync(dto);
            return Ok(resault);
        }

        [HttpPost("send-code-to-email")]
        public async Task<IActionResult> SendToEmail([FromForm] SendCodeToEmailViewModel email)
        {
            return Ok(_emailService.SendCodeAsync(email));
        }
    }
}
