using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehiclePerformance
    {
        [Key]
        public int PerformanceId { get; set; }

        [Required]
        [ForeignKey("TransmissionType")]
        public int TransmissionTypeId { get; set; }
        
        public string Engine { get; set; }
        public string Chassis { get; set; }
        public string Drivetrain { get; set; }

        // Navigation Properties
        public VehicleSpec VehicleSpec { get; set; }

        public TransmissionType TransmissionType { get; set; }
        public ICollection<VehiclePerformanceDriveMode> VehiclePerformanceDriveModes { get; set; } = new List<VehiclePerformanceDriveMode>();
    }
}
