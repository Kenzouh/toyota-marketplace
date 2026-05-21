using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehicleDimensionFuel
    {
        [Key]
        public int DimensionFuelId { get; set; }

        public float DimensionX { get; set; }
        public float DimensionY { get; set; }
        public float DimensionZ { get; set; }

        public float GroundClearance { get; set; }
        public int SeatingCapacity { get; set; }
        public float PayloadCapacity { get; set; }  
        public float FuelCapacity { get; set; }

        // Navigation Properties
        public VehicleSpec VehicleSpec { get; set; }
    }
}
