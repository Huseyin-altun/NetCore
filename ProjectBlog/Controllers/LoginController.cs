using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YazilimBlog.Models;
using YazilimBlog.Models.Context;

namespace YazilimBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ContextDb _contextDb;
        public LoginController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAdmin(Profile profile)
        {
            var data = _contextDb.Profiles.FirstOrDefault(x => x.UserName == profile.UserName && x.Password == profile.Password);
            if (data != null)
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,profile.UserName),

                };

                var Ident = new ClaimsIdentity(claim, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(Ident);
                await HttpContext.SignInAsync(principal);
                HttpContext.Session.SetInt32("Id", data.ProfileID);

                return RedirectToAction("Index","Panel");
                
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut(Profile profile) {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginAdmin", "Login");
        }
}
}
