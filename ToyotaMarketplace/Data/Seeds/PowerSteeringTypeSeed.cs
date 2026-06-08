using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;

namespace ToyotaMarketplace.Data.Seeds
{
    public class PowerSteeringTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.PowerSteeringTypes.Any())
            {
                context.PowerSteeringTypes.AddRange(
                    new PowerSteeringType { PowerSteeringTypeName = "Hydraulic" },
                    new PowerSteeringType { PowerSteeringTypeName = "Electric" },
                    new PowerSteeringType { PowerSteeringTypeName = "Electro-Hydraulic" }
                );
                context.SaveChanges();
            }
        }
    }
}
