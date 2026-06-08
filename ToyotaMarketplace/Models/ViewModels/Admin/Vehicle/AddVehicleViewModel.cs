using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.ViewModels.Admin.Vehicle
{
    public class AddVehicleViewModel
    {
        // ==================== Vehicle Hero Section ====================

        [Required]
        public string VehicleName { get; set; }

        public int VehicleSRP { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public int PowerTrainId { get; set; }

        public int? FuelTypeId { get; set; }

        public int Wheel { get; set; }

        public string Disclaimer { get; set; }

        // Multiple uploaded images
        public List<IFormFile> VehicleImages { get; set; } = new();

        // Multiple colors
        public List<int> VehicleColorIds { get; set; } = new();



        // ==================== Performance ====================

        public string Engine { get; set; }

        public int TransmissionTypeId { get; set; }

        public string Drivetrain { get; set; }

        public string Chassis { get; set; }

        // Multiple drive modes
        public List<int> DriveModeIds { get; set; } = new();



        // ==================== Technical Specifications ====================

        public string Suspension { get; set; }

        public string SteeringSystemName { get; set; }

        public string SteeringTypeName { get; set; }

        public int? PowerSteeringTypeId { get; set; }

        public int? FrontBrakeTypeId { get; set; }
        public int? RearBrakeTypeId { get; set; }

        public float MinimumTurningRadius { get; set; }

        public int? BatteryTypeId { get; set; }

        public string AntiLockBrakeSystem { get; set; }



        // ==================== Dimensions & Capacity ====================

        public float DimensionX { get; set; }

        public float DimensionY { get; set; }

        public float DimensionZ { get; set; }

        public float GroundClearance { get; set; }

        public int SeatingCapacity { get; set; }

        public float PayloadCapacity { get; set; }

        public float FuelCapacity { get; set; }



        // ==================== Exterior Features ====================

        public string Exterior { get; set; }

        public string TireDiskWheel { get; set; }



        // ==================== Interior Features ====================

        public string Interior { get; set; }

        public string MeterCluster { get; set; }

        public string MultiInfoDisplay { get; set; }

        public string Audio { get; set; }

        public string Ignition { get; set; }

        public string Function { get; set; }



        // ==================== Safety Features ====================

        public string Safety { get; set; }



        // ==================== Additional Information ====================

        public string ModelNote { get; set; }



        // ==================== Dropdown Data ====================

        public IEnumerable<SelectListItem>? VehicleTypes { get; set; }

        public IEnumerable<SelectListItem>? VehicleModels { get; set; }

        public IEnumerable<SelectListItem>? PowerTrains { get; set; }

        public IEnumerable<SelectListItem>? FuelTypes { get; set; }

        public IEnumerable<SelectListItem>? TransmissionTypes { get; set; }

        public IEnumerable<SelectListItem>? SteeringSystems { get; set; }

        public IEnumerable<SelectListItem>? SteeringTypes { get; set; }

        public IEnumerable<SelectListItem>? PowerSteeringTypes { get; set; }

        public IEnumerable<SelectListItem>? FrontBrakeTypes { get; set; }

        public IEnumerable<SelectListItem>? RearBrakeTypes { get; set; }

        public IEnumerable<SelectListItem>? BatteryTypes { get; set; }

        public IEnumerable<SelectListItem>? DriveModes { get; set; }

        public IEnumerable<SelectListItem>? VehicleColors { get; set; }

        public IEnumerable<SelectListItem>? VehicleColorCategories { get; set; }
    }
}