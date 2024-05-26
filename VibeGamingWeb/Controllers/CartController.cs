using VibeGamingWeb.DAL;
using VibeGamingWeb.Models;
using VibeGamingWeb.Models.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace VibeGamingWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly MainDbContext _context;

        public CartController(MainDbContext context)
        {
            _context = context;
        }
        // The method handles a GET request to display the user's cart.
        // It checks the user's authenticity, retrieves games from the cart from the database,
        // calculates the total price, adds a fixed shipping cost, and sets these in ViewBag.
        // Returns the cart view with the retrieved games.
        [Authorize]
        [Route("/checkout/cart")] // Defined URL route
        public IActionResult Cart()
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userId, out int userIdInt))
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }
            var cartItems = _context.Carts.Where(c => c.IdUser == userIdInt).ToList();
            float deliveryCost = cartItems.Any() ? 10.00f : 0.0f;
            ViewBag.TotalPrice = CalculateTotalPrice(cartItems);
            ViewBag.DeliveryCost = deliveryCost;
            ViewBag.VAT = ViewBag.TotalPrice + ViewBag.DeliveryCost;
            return View(cartItems);
        }

        // The method handles a POST request to remove a game from the user's cart.
        // It searches for the game in the cart by ID,
        // removes it from the database, and saves the changes. Redirects the user back to the cart view.
        [HttpPost]
        public IActionResult RemoveFromCart(int cartId)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.IdCart == cartId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart", "Cart");
        }

        // The method calculates the total price of all games in the cart.
        // Iterates through the cart's game list and sums the prices multiplied by the quantities for each game.
        // Returns the total price as a float value.
        private static float CalculateTotalPrice(List<VibeCart> cartItems)
        {
            float totalPrice = 0.0f;
            foreach (var item in cartItems)
            {
                totalPrice += item.CartGamePrice * item.CartGameQty;
            }
            return totalPrice;
        }

        // The method handles a POST request to update the quantity of a game in the user's cart.
        // It searches for the game in the cart by ID,
        // updates its quantity with the new value, and saves the changes in the database.
        // Redirects the user back to the cart view.
        [HttpPost]
        public IActionResult UpdateQuantity(int cartId, int quantity)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.IdCart == cartId);
            if (cartItem != null)
            {
                cartItem.CartGameQty = quantity;
                _context.SaveChanges();
            }
            return RedirectToAction("Cart", "Cart");
        }

    }
}
