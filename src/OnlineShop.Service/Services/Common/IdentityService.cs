using Microsoft.AspNetCore.Http;
using OnlineShop.Service.Interfaces.Common;

namespace OnlineShop.Service.Services.Common
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _accessor;
        public IdentityService(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }
        public int? Id
        {
            get
            {
                var res = _accessor.HttpContext!.User.FindFirst("Id");
                return res is not null ? int.Parse(res.Value) : null;
            }
        }

        public string Name
        {
            get
            {
                var result = _accessor.HttpContext!.User.FindFirst("FirstName");
                return (result is null) ? String.Empty : result.Value;
            }
        }
        public string Phone
        {
            get
            {
                var result = _accessor.HttpContext!.User.FindFirst("LastName");
                return (result is null) ? String.Empty : result.Value;
            }
        }

        public string Email
        {
            get
            {
                var res = _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
                return res is not null ? res.Value : string.Empty;
            }
        }

        public string Password
        {
            get
            {
                var result = _accessor.HttpContext!.User.FindFirst("ImagePath");
                return (result is null) ? String.Empty : result.Value;
            }
        }


    }
}
