using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class SteeringType
    {
        [Key]
        public int SteeringTypeId { get; set; }

        [Required]
        public string SteeringTypeName { get; set; }
    }
}
