using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToyotaMarketplace.Models.Users;

namespace ToyotaMarketplace.Models.Vehicles
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        [ForeignKey("VehicleModel")]
        public int VehicleModelId { get; set; }

        [Required]
        [ForeignKey("VehicleColor")]
        public int VehicleColorId { get; set; }

        [Required]
        [ForeignKey("ToyotaAdmin")]
        public int ToyotaAdminId { get; set; }
        
        [Required]
        public string VehicleName { get; set; }

        public int? VehicleSRP { get; set; }

        [Required]
        public string VehicleImg { get; set; }

        // Navigation Properties
        public ToyotaAdmin ToyotaAdmin { get; set; } // 1
        public VehicleModel VehicleModel { get; set; } // 1
        public VehicleColor VehicleColor { get; set; } // 1

        /*
            Visualization:
            Vehicles >|-----| ToyotaAdmin
            Vehicles >|-----| VehicleModel
            Vehicles >|-----| VehicleColor
        */
    }
}
