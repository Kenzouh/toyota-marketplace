using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class BrakeType
    {
        [Key]
        public int BrakeTypeId { get; set; }

        [Required]
        public string BrakeTypeName { get; set; }
    }
}
