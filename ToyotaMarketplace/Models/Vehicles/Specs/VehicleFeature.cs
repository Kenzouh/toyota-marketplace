using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class VehicleFeature
    {
        [Key]
        public int FeatureId { get; set; }
        public string Exterior { get; set; }
        public string TireDiskWheel { get; set; }
        public string Interior { get; set; }
        public string Audio { get; set; }
        public string MeterCluster { get; set; }
        public string MultiInfoDisplay { get; set; }
        public string Safety { get; set; }
        public string Ignition { get; set; }
        public string Function { get; set; }

        // Navigation Property
        public VehicleSpec VehicleSpec { get; set; }
    }
}