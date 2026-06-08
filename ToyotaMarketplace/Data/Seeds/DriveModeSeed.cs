using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;


namespace ToyotaMarketplace.Data.Seeds
{
    public class DriveModeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.DriveModes.Any())
            {
                context.DriveModes.AddRange(
                    new DriveMode { ModeName = "Eco" },
                    new DriveMode { ModeName = "Normal" },
                    new DriveMode { ModeName = "Sport" },
                    new DriveMode { ModeName = "EV" }
                );
                context.SaveChanges();
            }
        }
    }
}
