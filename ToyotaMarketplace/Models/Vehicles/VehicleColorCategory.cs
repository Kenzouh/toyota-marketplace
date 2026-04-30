using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles
{
    public class VehicleColorCategory
    {
        [Key]
        public int VehicleColorCategoryId { get; set; }

        [Required]
        public string VehicleColorCategoryName { get; set; }

        // Navigation Property
        public ICollection<VehicleColor> VehicleColors { get; set; }

        /*
            Visualization:
            VehicleColorCategories |-----|< VehicleColors
        */
    }
}
