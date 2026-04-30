using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyotaMarketplace.Models.Vehicles
{
    public class VehicleColor
    {
        [Key]
        public int VehicleColorId { get; set; }

        [Required]
        [ForeignKey("VehicleColor")]
        public int VehicleColorCategoryId { get; set; }

        [Required]
        public string VehicleColorName { get; set; }

        [Required]
        public string VehicleColorHexadecimal { get; set; }

        // Navigation Properties

        public VehicleColorCategory VehicleColorCategory { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        /*
            Visualization:
            VehicleColors |-----|< Vehicles
            VehicleColors >|-----| VehicleColorCategories
        */
    }
}
