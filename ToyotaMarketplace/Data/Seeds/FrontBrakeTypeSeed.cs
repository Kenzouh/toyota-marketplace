using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;


namespace ToyotaMarketplace.Data.Seeds
{
    public class FrontBrakeTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.FrontBrakeTypes.Any())
            {
                context.FrontBrakeTypes.AddRange(
                    new FrontBrakeType { FrontBrakeName = "Disc" }
                );

                context.SaveChanges();
            }
        }
    }
}
