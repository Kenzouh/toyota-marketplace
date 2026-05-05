using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Vehicles.Specs
{
    public class TransmissionType
    {
        [Key]
        public int TransmissionTypeId { get; set; }
        public string TransmissionName { get; set; }
    }
}
