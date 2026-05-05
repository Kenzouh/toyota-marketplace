using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class SteeringSystem
    {
        [Key]
        public int SteeringSystemId { get; set; }
        
        [Required]
        public string SteeringSystemName { get; set; }
    }
}
