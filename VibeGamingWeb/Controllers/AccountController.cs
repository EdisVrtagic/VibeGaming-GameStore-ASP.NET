using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using VibeGamingWeb.DAL;
using VibeGamingWeb.Models.DBEntities;

namespace VibeGamingWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly MainDbContext _context;

        public AccountController(MainDbContext context)
        {
            _context = context;
        }
        [Authorize] // Only authorized users have access
        [Route("/account/personal")] // Defined URL route
        // Data is retrieved through the currently logged-in user's ID from ClaimTypes
        // Check if the ID is valid, if not, redirect to the ErrorPage
        // Asynchronously fetch the user from the database
        // Also, if the user is not found, redirect to the ErrorPage
        // Asynchronously count the games added to the cart
        // Save the number of games added to the cart in ViewBag for display on the page
        // Return a view that displays user information
        public async Task<IActionResult> Account()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdString, out int userId))
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == userId);

            if (user == null)
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }
            var cartItemCount = await _context.Carts.CountAsync(c => c.IdUser == userId);
            ViewBag.CartItemCount = cartItemCount;
            return View(user);
        }

        [ValidateAntiForgeryToken] // Protection against Cross-Site Request Forgery attacks
        [HttpPost] // The method is invoked when a POST request is sent
        [Authorize] // Only authorized users have access
        [Route("/account/personal")] // Defined URL route
        // Data is retrieved through the currently logged-in user's ID from ClaimTypes
        // Check if the ID is valid, if not, redirect to the ErrorPage
        // Asynchronously fetch the user from the database
        // Also, if the user is not found, redirect to the ErrorPage
        // Update user data only if new fields in userData are filled and save new data to the database
        // After successful changes, refresh the UI for the user with the new data
        public async Task<IActionResult> Account(VibeUsers userData)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdString, out int userId))
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == userId);
            if (user == null)
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }
            if (!string.IsNullOrEmpty(userData.FirstName))
            {
                user.FirstName = userData.FirstName;
            }
            if (!string.IsNullOrEmpty(userData.LastName))
            {
                user.LastName = userData.LastName;
            }
            if (!string.IsNullOrEmpty(userData.Password))
            {
                user.Password = userData.Password;
            }
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Account");
        }
    }
}