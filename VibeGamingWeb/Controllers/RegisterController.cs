using VibeGamingWeb.DAL;
using VibeGamingWeb.Models;
using VibeGamingWeb.Models.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;

namespace VibeGamingWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MainDbContext _context;
        public RegisterController(MainDbContext context)
        {
            _context = context;
        }
        // GET method accessed when loading the registration page and the route used by default
        [Route("create/user-account")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        // POST method used to write the entered data and the route used after the method is executed
        [Route("create/user-account")]
        [HttpPost]
        public IActionResult Register(VibeUsers vusers)
        {
            _context.Add(vusers);
            _context.SaveChanges();
            return RedirectToAction("Login", "Login");
        }
    }
}
