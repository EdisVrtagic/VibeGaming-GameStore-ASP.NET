using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using VibeGamingWeb.DAL;
using VibeGamingWeb.Models.DBEntities;

namespace VibeGamingWeb.Controllers
{
    public class BuyGameController : Controller
    {
        private readonly MainDbContext _context;
        public BuyGameController(MainDbContext context)
        {
            _context = context;
        }
        [Route("p/{gameId}-buy-{gameTitle}")] // Defined URL route, retrieves game ID and name
        [HttpGet] // Method for GET request that fetches data
        public IActionResult BuyGame(string gameTitle, int gameId)
        {
            // Variables that enable access to data from tables Buys, Cates, Tips, Galls, Trailers, Specs based on the provided game ID
            var allGames = _context.Games.ToList();
            ViewBag.AllGames = allGames;
            var buy = _context.Buys.FirstOrDefault(b => b.IdGame == gameId);
            var cate = _context.Cates.FirstOrDefault(c => c.IdGame == gameId);
            var tip = _context.Tips.FirstOrDefault(t => t.IdGame == gameId);
            var galleries = _context.Galls.Where(g => g.IdGame == gameId).ToList();
            var trailers = _context.Trailers.Where(tr => tr.IdGame == gameId).ToList();
            var spe = _context.Specs.Where(sp => sp.IdGame == gameId).ToList();
            // If game data is not found or is null, return an error message
            if (buy == null || cate == null || tip == null || !galleries.Any() || !trailers.Any() || !spe.Any())
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }
            // Update gameTitle based on BuyName
            gameTitle = FormatTitle(buy.BuyName);

            // Redirect to the updated URL
            if (gameTitle != Request.RouteValues["gameTitle"]?.ToString())
            {
                return RedirectToActionPermanent(nameof(BuyGame), new { gameId, gameTitle });
            }
            // Full paths for fetching gallery and trailer images
            var galleryImages = galleries.Select(g => new VibeGall
            {
                GallImgPath = g.GallImgPath,
                GallImgTitle = g.GallImgTitle,
                GallImgDesc = g.GallImgDesc
            }).ToList();
            var trailerImages = trailers.Select(tr => new VibeTrailer
            {
                TraImgPath = tr.TraImgPath,
                TraLink = tr.TraLink
            }).ToList();

            // Pass data to ViewData
            ViewData["BuyWallImgPath"] = buy.BuyWallImgPath;
            ViewData["BuyName"] = buy.BuyName;
            ViewData["BuyPlatImgPath"] = $"/vgico/{buy.BuyPlatImgPath}";
            ViewData["BuyGameEdition"] = buy.BuyGameEdition;
            ViewData["BuyStockGame"] = buy.BuyStockGame;
            ViewData["BuyAgeRestrict"] = buy.BuyAgeRestrict;
            ViewData["BuyPrice"] = buy.BuyPrice;

            ViewData["CateOfOn"] = cate.CateOfOn;
            ViewData["CateDigKey"] = cate.CateDigKey;
            ViewData["CateGameSupp"] = cate.CateGameSupp;
            ViewData["CatePlayer"] = cate.CatePlayer;
            ViewData["CateDev"] = cate.CateDev;
            ViewData["CateRevNum"] = cate.CateRevNum;

            ViewData["TipGame1"] = tip.TipGame1;
            ViewData["TipGame2"] = tip.TipGame2;
            ViewData["TipGame3"] = tip.TipGame3;
            ViewData["TipGame4"] = tip.TipGame4;
            ViewData["TipBannPath"] = tip.TipBannPath;
            ViewData["TipAboutGame"] = tip.TipAboutGame;
            ViewData["TipTextGame"] = tip.TipTextGame;

            ViewData["GalleryImages"] = galleryImages;
            ViewData["TrailerImages"] = trailerImages;

            ViewData["SpecOSMin"] = spe.FirstOrDefault()?.SpecOSMin;
            ViewData["SpecProcMin"] = spe.FirstOrDefault()?.SpecProcMin;
            ViewData["SpecMemMin"] = spe.FirstOrDefault()?.SpecMemMin;
            ViewData["SpecGrapMin"] = spe.FirstOrDefault()?.SpecGrapMin;
            ViewData["SpecStorMin"] = spe.FirstOrDefault()?.SpecStorMin;

            ViewData["SpecOSMax"] = spe.FirstOrDefault()?.SpecOSMax;
            ViewData["SpecProcMax"] = spe.FirstOrDefault()?.SpecProcMax;
            ViewData["SpecMemMax"] = spe.FirstOrDefault()?.SpecMemMax;
            ViewData["SpecGrapMax"] = spe.FirstOrDefault()?.SpecGrapMax;
            ViewData["SpecStorMax"] = spe.FirstOrDefault()?.SpecStorMax;

            // Based on the currently logged-in user's ID from ClaimTypes, check the number of games added to the cart and pass this to ViewBag for display
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
            // ViewBag that receives the game title and ViewData that fetches IdGame
            ViewBag.Title = buy.BuyName;
            ViewData["IdGame"] = gameId;
            return View();
        }
        // Method for formatting text from URL into a page title to be, for example, (Test title) instead of (test-title)
        private static string FormatTitle(string gameTitle)
        {
            return gameTitle.Replace(" ", "-").ToLower();
        }
        // This method handles the POST request for purchasing a game. It checks the user's authenticity,
        // retrieves user data and game data, and adds or updates the game in the user's cart.
        // It also saves changes to the database and returns a JSON response if the change was successfully made.
        [HttpPost]
        public IActionResult BuyGame(int gameId)
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userId, out int userIdInt))
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }

            var user = _context.Users.FirstOrDefault(u => u.IdUser == userIdInt);
            if (user == null)
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }

            var game = _context.Games.FirstOrDefault(g => g.IdGame == gameId);
            if (game == null)
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }
            var existingCartItem = _context.Carts.FirstOrDefault(c => c.IdUser == userIdInt && c.IdGame == game.IdGame);
            if (existingCartItem != null)
            {
                if (existingCartItem.CartGameQty < 10)
                {
                    existingCartItem.CartGameQty++;
                }
            }
            else
            {
                var cartItem = new VibeCart
                {
                    CartEmail = user.Email,
                    CartImgPath = game.GameImgPath,
                    CartGameName = game.GameName,
                    CartGameQty = 1,
                    CartGamePrice = game.GamePrice,
                    IdUser = userIdInt,
                    IdGame = game.IdGame
                };
                _context.Carts.Add(cartItem);
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }
        // The method handles the GET request to get the number of games in the user's cart.
        // It checks the user's authenticity, retrieves the number of games in the cart from the database,
        // and returns it as a JSON response. If the user is not logged in or has no games in the cart, it returns 0 as the number of games.
        [HttpGet]
        public IActionResult GetCartItemCount()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                var cartItemCount = _context.Carts.Count(c => c.IdUser == int.Parse(userId));
                return Json(new { cartItemCount });
            }
            else
            {
                return Json(new { cartItemCount = 0 });
            }
        }

    }
}