using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Service.Common.Helpers;
using OnlineShop.Service.Common.Exceptions;
using OnlineShop.Service.Dtos.Accounts;
using OnlineShop.Service.Helpers;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Interfaces.Common;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Controllers
{

    [Route("accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;
        private readonly IIdentityService _identity;

        public AccountsController(IAccountService acccountService, IIdentityService identity)
        {
            this._service = acccountService;
            _identity = identity;

        }

        [HttpGet("login")]
        public ViewResult Login() => View("Login");

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var token = await _service.LoginAsync(accountLoginDto);



                    HttpContext.Response.Cookies.Append("X-Access-Token", token.ToString(), new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict
                    });

                    long id = HttpContextHelper.UserId;
                    var res = HttpContextHelper.UserRole;
                    if (GlobalVariables.Role == "Admin")
                    {
                        return RedirectToAction("Approved", "Admin", new { area = "" });
                    }
                    else if (GlobalVariables.Role == "User")
                    {
                        return RedirectToAction("Active", "users", new { area = "" });
                    }
                    else
                    {
                        return View();
                    }

                }
                catch (ModelErrorException modelError)
                {
                    ModelState.AddModelError(modelError.Property, modelError.Message);
                    return Login();
                }
                catch
                {
                    return Login();
                }
            }
            else return Login();
        }

        [HttpGet("register")]
        public ViewResult Register() => View("Register");

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _service.RegisterAsync(accountRegisterDto);
                if (result)
                {
                    return RedirectToAction("login", "accounts", new { area = "" });
                }
                else
                {
                    return Register();
                }
            }
            else return Register();
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Append("X-Access-Token", "", new CookieOptions()
            {
                Expires = TimeHelper.GetCurrentServerTime().AddDays(-1)
            });
            return RedirectToAction("Login", "Accounts", new { area = "" });
        }
    }
}
