using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class RearBrakeType
    {
        [Key]
        public int RearBrakeTypeId { get; set; }

        [Required]
        public string RearBrakeName { get; set; }

        // Navigation Property
        public ICollection<VehicleTechnical> VehicleTechnicals { get; set; } = new List<VehicleTechnical>();
    }
}
