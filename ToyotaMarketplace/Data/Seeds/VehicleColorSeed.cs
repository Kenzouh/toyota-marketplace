using System.Linq.Expressions;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class VehicleColorSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.VehicleColors.Any())
            {
                context.VehicleColors.AddRange(
                    
                );
            }
        }
    }
}
