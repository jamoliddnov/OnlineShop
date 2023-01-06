using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
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
    }
}
