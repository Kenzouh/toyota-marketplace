using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Models.ViewModels.Public
{
    public class HomeViewModel
    {
        public List<Vehicle> Vehicles { get; set; } = new();

        public List<VehicleType> VehicleTypes { get; set; } = new();

        public List<int> SeatingCapacities { get; set; } = new();

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }
    }
}