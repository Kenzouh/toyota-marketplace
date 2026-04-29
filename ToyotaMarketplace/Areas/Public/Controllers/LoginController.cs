using Microsoft.AspNetCore.Mvc;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    [Area("Public")]
    public class LoginController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
