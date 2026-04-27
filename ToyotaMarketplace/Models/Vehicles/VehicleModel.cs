using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyotaMarketplace.Models.Vehicles
{
    public class VehicleModel
    {
        [Key]
        public int VehicleModelId { get; set; }

        [Required]
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }

        [Required]
        public string ModelName { get; set; }

        // Navigation Properties
        public VehicleType VehicleType { get; set; } // 1
        public ICollection<Vehicle> Vehicles { get; set; } // N


        /*
            Visualization:
            Vehicles >|-----| VehicleModels
        */
    }
}
