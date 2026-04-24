using Microsoft.AspNetCore.Mvc;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }
    }
}
