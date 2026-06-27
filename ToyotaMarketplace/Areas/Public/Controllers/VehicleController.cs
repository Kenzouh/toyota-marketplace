using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Areas.Data;

namespace ToyotaMarketplace.Areas.Public.Controllers
{
    [Area("Public")]
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("View/{id}")]
        public IActionResult ViewVehicle(int id)
        {
            var vehicle = _context.Vehicles

                .Include(v => v.VehicleModel)
                    .ThenInclude(vm => vm.VehicleType)

                .Include(v => v.VehicleColor)

                .Include(v => v.PowerTrain)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehiclePerformance)
                        .ThenInclude(vp => vp.TransmissionType)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehiclePerformance)
                        .ThenInclude(vp => vp.VehiclePerformanceDriveModes)
                            .ThenInclude(vpdm => vpdm.DriveMode)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleTechnical)
                        .ThenInclude(vt => vt.SteeringSystem)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleTechnical)
                        .ThenInclude(vt => vt.SteeringType)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleTechnical)
                        .ThenInclude(vt => vt.PowerSteeringType)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleTechnical)
                        .ThenInclude(vt => vt.FrontBrakeType)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleTechnical)
                        .ThenInclude(vt => vt.RearBrakeType)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleTechnical)
                        .ThenInclude(vt => vt.BatteryType)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleDimensionFuel)

                .Include(v => v.VehicleSpec)
                    .ThenInclude(vs => vs.VehicleFeature)

                .FirstOrDefault(v => v.VehicleId == id);

            if (vehicle == null)
                return NotFound();

            return View(vehicle);
        }
    }
}