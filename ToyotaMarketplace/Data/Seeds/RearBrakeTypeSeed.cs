using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;


namespace ToyotaMarketplace.Data.Seeds
{
    public class RearBrakeTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.RearBrakeTypes.Any())
            {
                context.RearBrakeTypes.AddRange(
                    new RearBrakeType { RearBrakeName = "Drum" }
                );

                context.SaveChanges();
            }
        }
    }
}
