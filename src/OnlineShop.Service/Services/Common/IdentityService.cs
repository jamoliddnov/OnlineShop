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
                var res = _accessor.HttpContext!.User.Claims.FirstOrDefault(p => p.Type == "Id");
                return res is not null ? int.Parse(res.Value) : null;
            }
        }

        public string Name
        {
            get
            {
                var result = _accessor.HttpContext!.User.Claims.FirstOrDefault(p => p.Type == "FullName");
                return (result is null) ? String.Empty : result.Value;
            }
        }
        ////public string Phone
        ////{
        ////    get
        ////    {
        ////        var result = _accessor.HttpContext!.User.FindFirst("LastName");
        ////        return (result is null) ? String.Empty : result.Value;
        ////    }
        ////}

        ////public string Email
        ////{
        ////    get
        ////    {
        ////        var res = _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
        ////        return res is not null ? res.Value : string.Empty;
        ////    }
        ////}

        public string UserRole
        {
            get
            {
                var res = _accessor.HttpContext!.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
                return res is not null ? res : string.Empty;
            }
        }


        ////public string Password
        ////{
        ////    get
        ////    {
        ////        var result = _accessor.HttpContext!.User.FindFirst("ImagePath");
        ////        return (result is null) ? String.Empty : result.Value;
        ////    }
        ////}
        //public int? Id => throw new NotImplementedException();

        //public string UserRole => throw new NotImplementedException();
    }
}
