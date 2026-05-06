using Microsoft.Identity.Client;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehiclePerformanceDriveMode
    {
        public int PerformanceId { get; set; }
        public int DriveModeId { get; set; }

        // Navigation properties
        public VehiclePerformance VehiclePerformance { get; set; }
        public DriveMode DriveMode { get; set; }   
    }
}
