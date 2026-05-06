using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class BatteryType
    {
        [Key]
        public int BatteryTypeId { get; set; }

        [Required]
        public string BatteryName { get; set; }

        // Navigation Property
        public ICollection<VehicleTechnical> VehicleTechnicals { get; set; }
    }
}
