using Microsoft.AspNetCore.Mvc;

namespace VibeGamingWeb.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("page/error404")] // Defined URL route
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
