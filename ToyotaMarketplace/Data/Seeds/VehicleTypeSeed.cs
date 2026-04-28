using System.Linq;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class VehicleTypeSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.VehicleTypes.Any()) // Only seed if tbl is empty.
            {
                // .AddRange() = method that adds multiple records to the DB at once.
                context.VehicleTypes.AddRange(

                    // No need to put VehicleTypeId since auto-incremented by DB.

                    new VehicleType { VehicleTypeName = "Hatchbacks & Sedans", Wheel = 4 },
                    new VehicleType { VehicleTypeName = "Crossovers & SUVs", Wheel = 4 },
                    new VehicleType { VehicleTypeName = "MPVs", Wheel =  4 },
                    new VehicleType { VehicleTypeName = "Vans & Pick-ups", Wheel = 4 },
                    new VehicleType { VehicleTypeName = "Utility Vehicles", Wheel = 4 },
                    new VehicleType { VehicleTypeName = "Electrified", Wheel = 4 },
                    new VehicleType { VehicleTypeName = "Gazoo Racing", Wheel = 4 }
                );

                context.SaveChanges();

            }
        }
    }
}
