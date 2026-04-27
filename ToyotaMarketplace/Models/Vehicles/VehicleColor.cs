using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles
{
    public class VehicleColor
    {
        [Key]
        public int VehicleColorId { get; set; }
        
        [Required]
        public string VehicleColorName { get; set; }

        [Required]
        public string VehicleColorHexadecimal { get; set; }

        // Navigation Properties
        public ICollection<Vehicle> Vehicles { get; set; }

        /*
            Visualization:
            VehicleColors |-----|< Vehicles
        */
    }
}
