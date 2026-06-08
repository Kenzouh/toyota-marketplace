using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;

namespace ToyotaMarketplace.Data.Seeds
{
    public class FuelTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.FuelTypes.Any())
            {
                context.FuelTypes.AddRange(
                    new FuelType { FuelName = "Electricity" },
                    new FuelType { FuelName = "Gasoline" },
                    new FuelType { FuelName = "Diesel" }
                );
                context.SaveChanges();
            }
        }
    }
}
