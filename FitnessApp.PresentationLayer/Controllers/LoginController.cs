using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessApp.BLL;
using FitnessApp.Data.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Authentications authentication)
        {
            //authenticate using the manager

            var usr = AuthenticateManager.GetAuthentication(authentication.Username, authentication.Password);

            if (authentication == null)
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usr.Username),
                new Claim("FullName", usr.Username),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            if (TempData["ReturnUrl"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Index", "Home");

        }
    }
}
