using Microsoft.AspNetCore.Mvc;

namespace ToyotaMarketplace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {

        [HttpGet("Add")]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpGet("Edit")]
        public IActionResult EditVehicle()
        {
            return View();
        }
    }
}
