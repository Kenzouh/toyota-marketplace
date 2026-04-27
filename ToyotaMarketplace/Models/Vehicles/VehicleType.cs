using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }

        [Required]
        public string VehicleTypeName { get; set; }
        [Required]
        public int Wheel { get; set; }

        // Navigation Properties
        public ICollection<VehicleModel> VehicleModels { get; set; }


        /*
            Visualization:
            VehicleTypes |-----|< VehicleModels
        */

    }
}
