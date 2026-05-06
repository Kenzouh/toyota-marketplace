using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehicleSpec
    {
        [Key]
        public int VehicleSpecId { get; set; }

        // FK
        public int? PerformanceId { get; set; } // VehiclePerformances o|----||  VehicleSpecs
        public int? TechnicalId { get; set; }
        public int? DimensionFuelId { get; set; }
        public int? FeatureId { get; set; }

        public string Disclaimer { get; set; }
        public string ModelNote { get; set; }
        public float GroundClearance { get; set; }

        // Navigation property
        public Vehicle Vehicle { get; set; }

        public VehiclePerformance VehiclePerformance { get; set; }
        public VehicleTechnical VehicleTechnical { get; set; }
        public VehicleDimensionFuel VehicleDimensionFuel { get; set; }
        public VehicleFeature VehicleFeature { get; set; }
    }
}
