using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles.Specs;

namespace ToyotaMarketplace.Data.Seeds
{
    public class PowerTrainSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.PowerTrains.Any())
            {
                context.PowerTrains.AddRange(

                    new PowerTrain { PowerTrainType = "Gas" },
                    new PowerTrain { PowerTrainType = "Electric" },
                    new PowerTrain { PowerTrainType = "Hybrid" }
                );

                context.SaveChanges();
            }
        }
    }
}
