using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class PowerSteeringType
    {
        [Key]
        public int PowerSteeringTypeId { get; set; }

        [Required]
        public string PowerSteeringTypeName { get; set; }

        // Navigation Property
        public ICollection<VehicleTechnical> VehicleTechnicals { get; set; }
    }
}
