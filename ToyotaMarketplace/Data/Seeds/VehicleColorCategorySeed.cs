using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class VehicleColorCategorySeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.VehicleColorCategories.Any())
            {
                context.VehicleColorCategories.AddRange(

                    new VehicleColorCategory { VehicleColorCategoryName = "Beige" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Black" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Blue" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Bronze" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Gray" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Green" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Jade" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Orange" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Red" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Scarlet" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Silver" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Turquoise" },
                    new VehicleColorCategory { VehicleColorCategoryName = "White" },
                    new VehicleColorCategory { VehicleColorCategoryName = "Yellow" }
                );

                context.SaveChanges();
            }
        }
    }
}