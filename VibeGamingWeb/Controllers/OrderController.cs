using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using VibeGamingWeb.DAL;
using VibeGamingWeb.Models.DBEntities;

namespace VibeGamingWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly MainDbContext _context;

        public OrderController(MainDbContext context)
        {
            _context = context;
        }
        // Method to display user orders. 
        // Checks the user's authenticity, retrieves orders from the database, and displays them on the page.
        // Also, checks the number of games in the user's cart (if logged in) and sets that number in ViewBag.
        [Authorize]
        [Route("/account/myorders")] // Defined URL route
        public IActionResult Order()
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userId, out int userIdInt))
            {
                return RedirectToAction("Error", "Home");
            }
            var orderItems = _context.Orders.Where(c => c.IdUser == userIdInt).ToList();

            if (!string.IsNullOrEmpty(userId))
            {
                var cartItemCount = _context.Carts.Count(c => c.IdUser == int.Parse(userId));
                ViewBag.CartItemCount = cartItemCount;
            }
            else
            {
                ViewBag.CartItemCount = 0;
            }
            return View(orderItems);
        }

        // Method to remove a game from the user's order. 
        // Finds and deletes a specific order from the database.
        // After deletion, redirects the user to the page showing orders.
        [HttpPost]
        public IActionResult RemoveFromOrder(int orderId)
        {
            var orderItem = _context.Orders.FirstOrDefault(o => o.IdOrd == orderId);
            if (orderItem != null)
            {
                _context.Orders.Remove(orderItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Order", "Order");
        }
    }
}
