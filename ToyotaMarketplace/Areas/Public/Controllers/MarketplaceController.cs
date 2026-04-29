using Microsoft.AspNetCore.Mvc;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    [Area("Public")]
    public class MarketplaceController : Controller
    {
        [HttpGet("Marketplace")] // This route will be /Marketplace instead of /Marketplace/Index
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}