using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_auth.Auth;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace simple_auth.Controllers
{
    public class AuthController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl) {
            if (ModelState.IsValid)
            {
                IEnumerable<Claim> claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, model.Username) 
                };

                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Basic"));
				await HttpContext.Authentication.SignInAsync("MyCookieAuthApp", principal);
                return Redirect(returnUrl);
			}
            else
                return View(model);
        }

        public IActionResult AccessDenied() {
            return View();
        }

        public async Task<IActionResult> LogOut() {
            await HttpContext.Authentication.SignOutAsync("MyCookieAuthApp");
            return Redirect("/");
        }
    }
}
