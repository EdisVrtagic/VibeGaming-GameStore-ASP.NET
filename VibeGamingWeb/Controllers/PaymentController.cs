using System.Net;
using System.Net.Mail;
using VibeGamingWeb.DAL;
using VibeGamingWeb.Models.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace VibeGamingWeb.Controllers
{
    public class PaymentController : Controller
    {
        private readonly MainDbContext _context;

        public PaymentController(MainDbContext context)
        {
            _context = context;
        }

        // Method to display the payment processing page.
        // Checks the user's authenticity and retrieves games from the cart.
        // If there are no items in the cart, redirects the user to the cart page.
        // Otherwise, displays the payment processing page.
        [Route("/checkout/payment")] // Defined URL route
        [Authorize]
        public IActionResult Payment()
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userId, out int userIdInt))
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }

            var cartItems = _context.Carts.Where(c => c.IdUser == userIdInt).ToList();
            if (cartItems.Count == 0)
            {
                return RedirectToAction("Cart", "Cart");
            }
            return View();
        }

        // Method to send an email confirmation to the user about a successful order.
        // Checks if all fields are filled, retrieves user data, and sends an email to the user.
        // After sending the email, redirects the user to the page showing orders.
        [HttpPost]
        public IActionResult EmailSendUser(string firstName, string lastName, string address, string phoneNumber)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phoneNumber))
            {
                ModelState.AddModelError("", "Please fill in all fields.");
                return View("Payment");
            }

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

            string recipientEmail = user.Email;
            string recipientName = user.FirstName;
            string subject = "Your order - Vibe Gaming";
            string body = $"<div style=\"font-size: 16px;\">Hello {recipientName},<br><br>Your order has been successfully created.<br>In the next few days, your order will be processed, and someone from our administrators will contact you to confirm the order.<br><br>Best regards,<br>Your VG Support Team.</div>";
            var mail = new MailMessage
            {
                From = new MailAddress("Your business email address", "Vibe Gaming - Support")
            };
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new("smtp.gmail.com", 587);
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Your business email address", "email access password");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }

            return RedirectToAction("Order", "Order");
        }

        // Method for processing payments.
        // Checks the correctness of user data and the contents of the cart before processing the payment.
        // For each game in the cart, a new order is created and added to the database.
        // After successful processing, redirects the user to send an order email.
        [ValidateAntiForgeryToken] // Protection against Cross-Site Request Forgery attacks
        [HttpPost]
        public IActionResult ProcessPayment(string firstName, string lastName, string address, string phoneNumber)
        {

            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userId, out int userIdInt))
            {
                return RedirectToAction("ErrorPage", "ErrorPage");
            }

            var cartItems = _context.Carts.Where(c => c.IdUser == userIdInt).ToList();
            if (cartItems.Count == 0)
            {
                return RedirectToAction("Cart", "Cart");
            }

            foreach (var cartItem in cartItems)
            {
                var order = new VibeOrder
                {
                    OrdFirstName = firstName,
                    OrdLastName = lastName,
                    OrdAddress = address,
                    OrdPhoneNum = phoneNumber,
                    OrdImgPath = cartItem.CartImgPath,
                    OrdGameName = cartItem.CartGameName,
                    OrdGameQty = cartItem.CartGameQty,
                    OrdGamePrice = cartItem.CartGamePrice,
                    IdUser = userIdInt,
                    IdGame = cartItem.IdGame,
                    OrdTotalNum = cartItem.CartGameQty * cartItem.CartGamePrice + 10
                };
                _context.Orders.Add(order);
            }
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();

            return EmailSendUser(firstName, lastName, address, phoneNumber);
        }
    }
}
