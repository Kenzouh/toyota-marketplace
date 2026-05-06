using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class BrakeType
    {
        [Key]
        public int BrakeTypeId { get; set; }

        [Required]
        public string FrontBrake { get; set; }

        [Required]
        public string RearBrake { get; set; }

        // Navigation Property
        public ICollection<VehicleTechnical> VehicleTechnicals { get; set; }
    }
}
