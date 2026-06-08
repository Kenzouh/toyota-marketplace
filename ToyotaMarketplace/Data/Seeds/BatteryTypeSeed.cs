using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;


namespace ToyotaMarketplace.Data.Seeds
{
    public class BatteryTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.BatteryTypes.Any())
            {
                context.BatteryTypes.AddRange(
                    new BatteryType { BatteryName = "Lithium-Ion" },
                    new BatteryType { BatteryName = "Nickel-Metal Hydride (NiMH)" },
                    new BatteryType { BatteryName = "Lead-Acid" },
                    new BatteryType { BatteryName = "Solid-State" }
                );
                context.SaveChanges();
            }
        }
    }
}
