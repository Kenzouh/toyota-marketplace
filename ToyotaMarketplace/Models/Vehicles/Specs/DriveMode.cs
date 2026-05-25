using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class DriveMode
    {
        [Key]
        public int DriveModeId { get; set; }

        [Required]
        public string ModeName { get; set; }

        // Navigation Property
        public ICollection<VehiclePerformanceDriveMode> VehiclePerformanceDriveModes { get; set; } = new List<VehiclePerformanceDriveMode>();
    }
}
