using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;
using System.Diagnostics.Contracts;

namespace simple_auth.Auth
{
    public static class MyCookieAuthValidator
    {
        public static async Task ValidateAsync(CookieValidatePrincipalContext context) {
            var userRepository = (IUserRepository)context.HttpContext.RequestServices.GetService(typeof(IUserRepository));
            ClaimsPrincipal userPrincipal = context.Principal;

            if (userRepository.IsLocked(userPrincipal.Identity.Name)) {
                context.RejectPrincipal();
                await context.HttpContext.Authentication.SignOutAsync("MyCookieAuthApp");
			}
        }
    }
}
