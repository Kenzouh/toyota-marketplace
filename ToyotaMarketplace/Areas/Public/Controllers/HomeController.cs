using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.ViewModels.Public;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    [Area("Public")]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index(
            int? vehicleTypeId,
            int? seatingCapacity,
            int? minPrice,
            int? maxPrice,
            string? sortBy)
        {
            var query = _context.Vehicles
                .Include(v => v.VehicleModel)
                    .ThenInclude(vm => vm.VehicleType)
                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleDimensionFuel)
                .AsQueryable();

            // Vehicle Type Filter
            if (vehicleTypeId.HasValue)
            {
                query = query.Where(v =>
                    v.VehicleModel.VehicleTypeId == vehicleTypeId.Value);
            }

            // Seating Capacity Filter
            if (seatingCapacity.HasValue)
            {
                query = query.Where(v =>
                    v.VehicleSpec.VehicleDimensionFuel.SeatingCapacity ==
                    seatingCapacity.Value);
            }

            // Min Price Filter
            if (minPrice.HasValue)
            {
                query = query.Where(v =>
                    v.VehicleSRP >= minPrice.Value);
            }

            // Max Price Filter
            if (maxPrice.HasValue)
            {
                query = query.Where(v =>
                    v.VehicleSRP <= maxPrice.Value);
            }

            // Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name":
                        query = query.OrderBy(v => v.VehicleModel.ModelName);
                        break;

                    case "price":
                        query = query.OrderBy(v => v.VehicleSRP);
                        break;
                }
            }

            var vm = new HomeViewModel
            {
                Vehicles = query.ToList(),

                VehicleTypes = _context.VehicleTypes
                    .OrderBy(v => v.VehicleTypeName)
                    .ToList(),

                SeatingCapacities = _context.VehicleDimensionFuels
                    .Select(v => v.SeatingCapacity)
                    .Distinct()
                    .OrderBy(v => v)
                    .ToList(),

                MinPrice = _context.Vehicles
                    .Min(v => v.VehicleSRP) ?? 0,

                MaxPrice = _context.Vehicles
                    .Max(v => v.VehicleSRP) ?? 0

            };



            return View(vm);
        }

        [HttpGet("Contact")]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}