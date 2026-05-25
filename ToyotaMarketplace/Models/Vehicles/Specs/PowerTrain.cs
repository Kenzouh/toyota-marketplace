using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class PowerTrain
    {
        [Key]
        public int PowerTrainId { get; set; }

        [Required]
        public string PowerTrainType { get; set; }

        // Navigation Property
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
