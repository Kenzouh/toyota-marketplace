using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;

namespace ToyotaMarketplace.Data.Seeds
{
    public class TransmissionTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.TransmissionTypes.Any())
            {
                context.TransmissionTypes.AddRange(

                    new TransmissionType { TransmissionName = "Manual" },
                    new TransmissionType { TransmissionName = "Automatic" },
                    new TransmissionType { TransmissionName = "CVT" }
                );

                context.SaveChanges();
            }
        }
    }
}
