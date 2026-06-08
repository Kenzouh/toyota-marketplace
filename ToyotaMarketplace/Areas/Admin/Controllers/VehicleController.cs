using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;
using ToyotaMarketplace.Models.ViewModels.Admin.Vehicle;

namespace ToyotaMarketplace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public VehicleController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // Helper
        private void PopulateDropdowns(AddVehicleViewModel vm)
        {
            vm.VehicleTypes = _context.VehicleTypes
                .Select(v => new SelectListItem
                {
                    Value = v.VehicleTypeId.ToString(),
                    Text = v.VehicleTypeName
                });

            vm.VehicleModels = _context.VehicleModels
                .Select(v => new SelectListItem
                {
                    Value = v.VehicleModelId.ToString(),
                    Text = v.ModelName
                });

            vm.PowerTrains = _context.PowerTrains
                .Select(v => new SelectListItem
                {
                    Value = v.PowerTrainId.ToString(),
                    Text = v.PowerTrainType
                });

            vm.FuelTypes = _context.FuelTypes
                .Select(v => new SelectListItem
                {
                    Value = v.FuelTypeId.ToString(),
                    Text = v.FuelName
                });

            vm.TransmissionTypes = _context.TransmissionTypes
                .Select(v => new SelectListItem
                {
                    Value = v.TransmissionTypeId.ToString(),
                    Text = v.TransmissionName
                });

            vm.PowerSteeringTypes = _context.PowerSteeringTypes
                .Select(v => new SelectListItem
                {
                    Value = v.PowerSteeringTypeId.ToString(),
                    Text = v.PowerSteeringTypeName
                });

            vm.FrontBrakeTypes = _context.FrontBrakeTypes
                .Select(v => new SelectListItem
                {
                    Value = v.FrontBrakeTypeId.ToString(),
                    Text = $"{v.FrontBrakeName}"
                });

            vm.RearBrakeTypes = _context.RearBrakeTypes
                .Select(v => new SelectListItem
                {
                    Value = v.RearBrakeTypeId.ToString(),
                    Text = $"{v.RearBrakeName}"
                });

            vm.BatteryTypes = _context.BatteryTypes
                .Select(v => new SelectListItem
                {
                    Value = v.BatteryTypeId.ToString(),
                    Text = v.BatteryName
                });

            vm.DriveModes = _context.DriveModes
                .Select(v => new SelectListItem
                {
                    Value = v.DriveModeId.ToString(),
                    Text = v.ModeName
                });

            vm.VehicleColors = _context.VehicleColors
                .Select(v => new SelectListItem
                {
                    Value = v.VehicleColorId.ToString(),
                    Text = v.VehicleColorName
                });

            vm.VehicleColorCategories = _context.VehicleColorCategories
                .Select(v => new SelectListItem
                {
                    Value = v.VehicleColorCategoryId.ToString(),
                    Text = v.VehicleColorCategoryName
                });
        }

        [HttpGet("Add")]
        public IActionResult AddVehicle()
        {
            AddVehicleViewModel vm = new AddVehicleViewModel
            {
                VehicleTypes = _context.VehicleTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.VehicleTypeId.ToString(),
                        Text = v.VehicleTypeName
                    }),

                VehicleModels = _context.VehicleModels
                    .Select(v => new SelectListItem
                    {
                        Value = v.VehicleModelId.ToString(),
                        Text = v.ModelName
                    }),

                PowerTrains = _context.PowerTrains
                    .Select(v => new SelectListItem
                    {
                        Value = v.PowerTrainId.ToString(),
                        Text = v.PowerTrainType
                    })
                    .ToList(),

                FuelTypes = _context.FuelTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.FuelTypeId.ToString(),
                        Text = v.FuelName
                    })
                    .ToList(),

                TransmissionTypes = _context.TransmissionTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.TransmissionTypeId.ToString(),
                        Text = v.TransmissionName
                    })
                    .ToList(),

                SteeringTypes = _context.SteeringTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.SteeringTypeId.ToString(),
                        Text = v.SteeringTypeName
                    })
                    .ToList(),

                PowerSteeringTypes = _context.PowerSteeringTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.PowerSteeringTypeId.ToString(),
                        Text = v.PowerSteeringTypeName
                    }),

                FrontBrakeTypes = _context.FrontBrakeTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.FrontBrakeTypeId.ToString(),
                        Text = $"{v.FrontBrakeName}"
                    }),

                RearBrakeTypes = _context.RearBrakeTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.RearBrakeTypeId.ToString(),
                        Text = v.RearBrakeName
                    }),

                BatteryTypes = _context.BatteryTypes
                    .Select(v => new SelectListItem
                    {
                        Value = v.BatteryTypeId.ToString(),
                        Text = v.BatteryName
                    }),

                DriveModes = _context.DriveModes
                    .Select(v => new SelectListItem
                    {
                        Value = v.DriveModeId.ToString(),
                        Text = v.ModeName
                    }),

                VehicleColorCategories = _context.VehicleColorCategories
                    .Select(v => new SelectListItem
                    {
                        Value = v.VehicleColorCategoryId.ToString(),
                        Text = v.VehicleColorCategoryName
                    }),

                VehicleColors = _context.VehicleColors
                    .Select(v => new SelectListItem
                    {
                        Value = v.VehicleColorId.ToString(),
                        Text = v.VehicleColorName
                    })
            };

            // ====================== Dropdown data rendering section ======================

            ViewBag.VehicleColorsData = _context.VehicleColors
                .Select(v => new
                {
                    v.VehicleColorId,
                    v.VehicleColorCategoryId,
                    v.VehicleColorName,
                    v.VehicleColorHexadecimal
                })
                .ToList();

            ViewBag.VehicleModelsData = _context.VehicleModels
                .Select(v => new
                {
                    v.VehicleModelId,
                    v.VehicleTypeId,
                    v.ModelName
                })
                .ToList();
            return View(vm);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(AddVehicleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(vm);

                return View(vm);
            }

            // Save Images

            List<string> imagePaths = new();

            if (vm.VehicleImages != null && vm.VehicleImages.Any())
            {
                string vehicleTypeName = await _context.VehicleTypes
                    .Where(v => v.VehicleTypeId == vm.VehicleTypeId)
                    .Select(v => v.VehicleTypeName)
                    .FirstAsync();

                string vehicleModelName = await _context.VehicleModels
                    .Where(v => v.VehicleModelId == vm.VehicleModelId)
                    .Select(v => v.ModelName)
                    .FirstAsync();

                string folderPath = Path.Combine(
                    _environment.WebRootPath,
                    "uploads",
                    "images",
                    vehicleTypeName,
                    vehicleModelName,
                    vm.VehicleName
                    );

                Directory.CreateDirectory(folderPath);

                foreach (var image in vm.VehicleImages)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    
                    string fullPath = Path.Combine(folderPath, fileName);

                    using FileStream stream = new(fullPath, FileMode.Create);

                    await image.CopyToAsync(stream);

                    string relativePath = $"/uploads/images/{vehicleTypeName}/{vehicleModelName}/{vm.VehicleName}/{fileName}";

                    imagePaths.Add(relativePath);
                }
            }

            // ============================ SPEC TABLES ============================

            // VehiclePerformance

            var vehiclePerformance = new VehiclePerformance
            {
                Engine = vm.Engine,
                TransmissionTypeId = vm.TransmissionTypeId,
                Drivetrain = vm.Drivetrain,
                Chassis = vm.Chassis
            };

            _context.VehiclePerformances.Add(vehiclePerformance);
            await _context.SaveChangesAsync();

            // ============================ DriveModes ============================

            foreach (var driveModeId in vm.DriveModeIds)
            {
                _context.VehiclePerformanceDriveModes.Add(
                    new VehiclePerformanceDriveMode
                    {
                        PerformanceId = vehiclePerformance.PerformanceId,
                        DriveModeId = driveModeId
                    });
            }

            await _context.SaveChangesAsync();


            // ============================ VehicleTechnical ============================

            // Steering System
            var steeringSystem = await _context.SteeringSystems
                .FirstOrDefaultAsync(x =>
                    x.SteeringSystemName == vm.SteeringSystemName);

            if (steeringSystem == null)
            {
                steeringSystem = new SteeringSystem
                {
                    SteeringSystemName = vm.SteeringSystemName
                };

                _context.SteeringSystems.Add(steeringSystem);
                await _context.SaveChangesAsync();
            }

            // SteeringType
            var steeringType = await _context.SteeringTypes
                .FirstOrDefaultAsync(x =>
                    x.SteeringTypeName == vm.SteeringTypeName);

            if (steeringType == null)
            {
                steeringType = new SteeringType
                {
                    SteeringTypeName = vm.SteeringTypeName
                };

                _context.SteeringTypes.Add(steeringType);
                await _context.SaveChangesAsync();
            }

            var vehicleTechnical = new VehicleTechnical
            {
                Suspension = vm.Suspension,
                MinimumTurningRadius = vm.MinimumTurningRadius,
                AntiLockBrakeSystem = vm.AntiLockBrakeSystem,

                FuelTypeId = vm.FuelTypeId,
                BatteryTypeId = vm.BatteryTypeId,
                PowerSteeringTypeId = vm.PowerSteeringTypeId,
                FrontBrakeTypeId = vm.FrontBrakeTypeId,
                RearBrakeTypeId = vm.RearBrakeTypeId,

                SteeringSystemId = steeringSystem.SteeringSystemId,
                SteeringTypeId = steeringType.SteeringTypeId
            };

            _context.VehicleTechnicals.Add(vehicleTechnical);
            await _context.SaveChangesAsync();

            // VehicleDimensionFuel
            var vehicleDimensionFuel = new VehicleDimensionFuel
            {
                DimensionX = vm.DimensionX,
                DimensionY = vm.DimensionY,
                DimensionZ = vm.DimensionZ,

                GroundClearance = vm.GroundClearance,
                SeatingCapacity = vm.SeatingCapacity,
                PayloadCapacity = vm.PayloadCapacity,
                FuelCapacity = vm.FuelCapacity
            };

            _context.VehicleDimensionFuels.Add(vehicleDimensionFuel);
            await _context.SaveChangesAsync();

            // VehicleFeature
            var vehicleFeature = new VehicleFeature
            {
                Exterior = vm.Exterior,
                TireDiskWheel = vm.TireDiskWheel,

                Interior = vm.Interior,
                MeterCluster = vm.MeterCluster,
                MultiInfoDisplay = vm.MultiInfoDisplay,
                Audio = vm.Audio,
                Ignition = vm.Ignition,
                Function = vm.Function,

                Safety = vm.Safety
            };

            _context.VehicleFeatures.Add(vehicleFeature);
            await _context.SaveChangesAsync();

            // VehicleSpec
            var vehicleSpec = new VehicleSpec
            {
                Disclaimer = vm.Disclaimer,
                ModelNote = vm.ModelNote,

                PerformanceId = vehiclePerformance.PerformanceId,
                TechnicalId = vehicleTechnical.TechnicalId,
                DimensionFuelId = vehicleDimensionFuel.DimensionFuelId,
                FeatureId = vehicleFeature.FeatureId
            };

            _context.VehicleSpecs.Add(vehicleSpec);
            await _context.SaveChangesAsync();

            // Vehicle
            var vehicle = new Models.Vehicles.Vehicle
            {
                VehicleName = vm.VehicleName,
                VehicleSRP = vm.VehicleSRP,

                VehicleModelId = vm.VehicleModelId,
                PowerTrainId = vm.PowerTrainId,

                VehicleSpecId = vehicleSpec.VehicleSpecId,

                VehicleImg = JsonSerializer.Serialize(imagePaths),

                DatePosted = DateTime.Now,

                ToyotaAdminId = 1, // replace with logged-in admin id

                VehicleColorId = vm.VehicleColorIds.First()
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home", new { area = "Public" });
        }



        [HttpGet("Edit")]
        public IActionResult EditVehicle()
        {
            return View();
        }
    }
}
