using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class FuelType
    {
        [Key]
        public int FuelTypeId { get; set; }

        [Required]
        public string FuelName { get; set; }

        // Navigation Property
        public ICollection<VehicleTechnical> VehicleTechnicals { get; set; } = new List<VehicleTechnical>();
    }
}