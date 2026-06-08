using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class FrontBrakeType
    {
        [Key]
        public int FrontBrakeTypeId { get; set; }

        [Required]
        public string FrontBrakeName { get; set; }

        // Navigation Property
        public ICollection<VehicleTechnical> VehicleTechnicals { get; set; } = new List<VehicleTechnical>();
    }
}
