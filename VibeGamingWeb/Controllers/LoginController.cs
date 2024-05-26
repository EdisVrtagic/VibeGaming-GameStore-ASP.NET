using VibeGamingWeb.DAL;
using VibeGamingWeb.Models;
using VibeGamingWeb.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VibeGamingWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly MainDbContext _context;

        public LoginController(MainDbContext context)
        {
            _context = context;
        }
        // Method to display the login form to the user. 
        // If the user is already logged in, redirects them to the main page. 
        // Otherwise, displays the login form. Optional returnUrl allows returning to the previous page after logging in.
        [HttpGet]
        [Route("/login/user-account")] // Defined URL route
        public IActionResult Login(string? returnUrl = null)
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("VPage", "MainPage");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(new VibeUsers());
        }

        // Method to log in the user. Checks the user's credentials from the database.
        // If the credentials are correct, creates the user's identity and logs them in via cookies.
        // Allows an optional returnUrl for redirection after logging in.
        [HttpPost]
        [Route("/login/user-account")] // Defined URL route
        public async Task<IActionResult> Login(VibeUsers _loginC, string? returnUrl = null)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.Email == _loginC.Email && m.Password == _loginC.Password);

            if (user == null)
            {
                ViewBag.LoginStatus = 0;
                return View(_loginC);
            }
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.NameIdentifier, user.IdUser.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("VPage", "MainPage");
            }
        }

        // Method to log out the user from the profile. 
        // Checks the user's authenticity, logs them out via cookies, and clears the browser's memory.
        // Finally, redirects the user to the home page.
        [Authorize]
        [Route("/user-logout")] // Defined URL route
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Clearing the memory from the browser
            Response.Headers["Cache-Control"] = "no-cache, no-store";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "-1";
            // Deleting all cookies
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            // Redirect to the home page
            await Task.Delay(2000);
            return RedirectToAction("VPage", "MainPage");
        }
    }
}