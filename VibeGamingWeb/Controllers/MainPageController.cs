using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using VibeGamingWeb.DAL;
using VibeGamingWeb.Models;
using VibeGamingWeb.Models.DBEntities;

namespace VibeGamingWeb.Controllers
{
    public class MainPageController : Controller
    {
        private readonly MainDbContext _context;
        public MainPageController(MainDbContext context)
        {
            _context = context;
        }
        // Method to display the main page of the application (VPage). 
        // Retrieves all games from the database and sorts them by platforms.
        // Sets all game groups in ViewBag for display on the page.
        // Also, checks the number of games in the user's cart (if logged in) and sets that number in ViewBag.
        [Route("/en-BS/vibehome")] // Defined URL route
        [HttpGet]
        public IActionResult VPage()
        {
            var allGames = _context.Games.ToList();
            ViewBag.AllGames = allGames;
            var pcGames = _context.Games.Where(g => g.GamePlatform == "PC").ToList();
            var playstationGames = _context.Games.Where(g => g.GamePlatform == "PlayStation").ToList();
            var xboxGames = _context.Games.Where(g => g.GamePlatform == "Xbox").ToList();
            var nintendoGames = _context.Games.Where(g => g.GamePlatform == "Nintendo").ToList();
            ViewBag.PcGames = pcGames;
            ViewBag.PlaystationGames = playstationGames;
            ViewBag.XboxGames = xboxGames;
            ViewBag.NintendoGames = nintendoGames;
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                var cartItemCount = _context.Carts.Count(c => c.IdUser == int.Parse(userId));
                ViewBag.CartItemCount = cartItemCount;
            }
            else
            {
                ViewBag.CartItemCount = 0;
            }
            return View();
        }

        // Method that redirects the user to a page with a message that games were not found.
        public IActionResult NoGamesFound()
        {
            return RedirectToAction("ErrorPage", "ErrorPage");
        }
    }
}