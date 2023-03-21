﻿using Microsoft.AspNetCore.Http;

#pragma warning disable

namespace OnlineShop.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor { get; set; }

        public static HttpContext HttpContext => Accessor?.HttpContext;

        public static long UserId => GetUserId();


        public static string UserRole => HttpContext?.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        private static long GetUserId()
        {
            long id;
            bool canParse = long.TryParse(HttpContext.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);
            if (canParse)
            {
                return id;
            }
            return 0;
        }
    }
}
