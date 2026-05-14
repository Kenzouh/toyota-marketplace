using Microsoft.AspNetCore.Mvc;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    [Area("Public")]
    public class VehicleController : Controller
    {
        [HttpGet("View")]
        public IActionResult ViewVehicle()
        {
            return View();
        }
    }
}
