using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class VehicleModelSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.VehicleModels.Any())
            {
                context.VehicleModels.AddRange(

                    // (1) Hatchbacks & Sedans
                    new VehicleModel { VehicleTypeId = 1, ModelName = "ATIV" },
                    new VehicleModel { VehicleTypeId = 1, ModelName = "Camry" },
                    new VehicleModel { VehicleTypeId = 1, ModelName = "Corolla Altis" },
                    new VehicleModel { VehicleTypeId = 1, ModelName = "Vios" },
                    new VehicleModel { VehicleTypeId = 1, ModelName = "Wigo" },

                    // (2) Crossovers & SUVs
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Urban Cruiser BEV" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Raize" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Veloz" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Yaris Cross" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Corolla Cross" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "bZ4X" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "RAV4" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Rush" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Fortuner" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Land Cruiser" },
                    new VehicleModel { VehicleTypeId = 2, ModelName = "Land Cruiser Prado" },

                    // (3) MPVs
                    new VehicleModel { VehicleTypeId = 3, ModelName = "Avanza" },
                    new VehicleModel { VehicleTypeId = 3, ModelName = "Innova" },
                    new VehicleModel { VehicleTypeId = 3, ModelName = "Zenix" },

                    // (4) Vans & Pick-ups
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Hiace" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Commuter Deluxe" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Super Grandia" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "GL Grandia" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "GL Grandia Tourer" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Coaster" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Alphard" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Hilux" },
                    new VehicleModel { VehicleTypeId = 4, ModelName = "Hilux Fleet" },

                    // (5) Utility Vehicles
                    new VehicleModel { VehicleTypeId = 5, ModelName = "Tamaraw" },
                    new VehicleModel { VehicleTypeId = 5, ModelName = "Lite Ace" },

                    // (6) Electrified
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Urban Cruiser BEV" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Yaris Cross" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Corolla Cross" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "ATIV" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "bZ4X" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "RAV4" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Camry" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Zenix" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Corolla Altis" },
                    new VehicleModel { VehicleTypeId = 6, ModelName = "Alphard" },

                    // (7) Gazoo Racing
                    new VehicleModel { VehicleTypeId = 7, ModelName = "GR Yaris" },
                    new VehicleModel { VehicleTypeId = 7, ModelName = "Corolla Altis GR-5" },
                    new VehicleModel { VehicleTypeId = 7, ModelName = "Hilux GR-S"},
                    new VehicleModel { VehicleTypeId = 7, ModelName = "Rush GR-S" },
                    new VehicleModel { VehicleTypeId = 7, ModelName = "Fortuner GR-S" }
                );

                context.SaveChanges();
            }
        }
    }
}
