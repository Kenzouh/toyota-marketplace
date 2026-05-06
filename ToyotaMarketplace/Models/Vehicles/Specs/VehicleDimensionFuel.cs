using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehicleDimensionFuel
    {
        [Key]
        public int DimensionFuelId { get; set; }

        public string Dimension { get; set; }
        public float GroundClearance { get; set; }
        public int SeatingCapacity { get; set; }
        public float PayloadCapacity { get; set; }  
        public float FuelCapacity { get; set; }

        // Navigation Properties
        public VehicleSpec VehicleSpec { get; set; }
    }
}
