using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehicleTechnical
    {
        [Key]
        public int TechnicalId { get; set; }

        // FKs
        public int? BatteryTypeId { get; set; }
        public int? SteeringSystemId { get; set; }
        public int? SteeringTypeId { get; set; }
        public int? PowerSteeringTypeId { get; set; }
        public int? BrakeTypeId { get; set;}
        public int? FuelTypeId { get; set; }


        public string Suspension { get; set; }
        public float MinimumTurningRadius { get; set; }
        public string AntiLockBrakeSystem { get; set; }

        // Navigation Properties
        public VehicleSpec VehicleSpec { get; set; }

        public BatteryType BatteryType { get; set; }
        public SteeringSystem SteeringSystem { get; set; }
        public SteeringType SteeringType { get; set; }
        public PowerSteeringType PowerSteeringType { get; set; }
        public BrakeType BrakeType { get; set; }
        public FuelType FuelType { get; set; }  
    }
}
