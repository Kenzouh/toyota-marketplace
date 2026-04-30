using System.Linq.Expressions;
using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class VehicleColorSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.VehicleColors.Any())
            {
                context.VehicleColors.AddRange(
                    
                    // Beige
                    new VehicleColor { VehicleColorCategoryId = 1, VehicleColorName = "Beige Metallic", VehicleColorHexadecimal = "ccb08c" },

                    // Black
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Black", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Black 1", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Black 3", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Black Metallic 1", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Black Metallic 2", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Black Mica", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Altitude Black Mica", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Attitude Black Mica", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Attitude Black Mica (2-Tone)", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Sparkling Black Pearl Crystal Shine", VehicleColorHexadecimal = "08112f" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Crystal Black Silica", VehicleColorHexadecimal = "000000" },
                    new VehicleColor { VehicleColorCategoryId = 2, VehicleColorName = "Precious Black", VehicleColorHexadecimal = "000000" },

                    // Blue
                    new VehicleColor { VehicleColorCategoryId = 3, VehicleColorName = "Celestial Blue", VehicleColorHexadecimal = "023087" },
                    new VehicleColor { VehicleColorCategoryId = 3, VehicleColorName = "Grayish Blue Mica Metallic", VehicleColorHexadecimal = "263243" },
                    new VehicleColor { VehicleColorCategoryId = 3, VehicleColorName = "Dark Blue Mica Metallic", VehicleColorHexadecimal = "0e1538" },
                    new VehicleColor { VehicleColorCategoryId = 3, VehicleColorName = "Sapphire Blue Pearl", VehicleColorHexadecimal = "000048" },
                    new VehicleColor { VehicleColorCategoryId = 3, VehicleColorName = "Dawn Blue Metallic", VehicleColorHexadecimal = "001b60" },

                    // Bronze
                    new VehicleColor { VehicleColorCategoryId = 4, VehicleColorName = "Avant-Garde Bronze Metallic", VehicleColorHexadecimal = "e8e1e1" },
                    new VehicleColor { VehicleColorCategoryId = 4, VehicleColorName = "Oxide Bronze Metallic", VehicleColorHexadecimal = "51524d" },

                    // Gray
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Gray Metallic", VehicleColorHexadecimal = "515151" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Cement Gray Metallic", VehicleColorHexadecimal = "8c9093" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Urban Rock", VehicleColorHexadecimal = "bbbbbd" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Matte Storm Gray Metallic", VehicleColorHexadecimal = "505d6d" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Magnetite Gray Metallic", VehicleColorHexadecimal = "2b2b2b" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Volcanic Ash Gray Metallic", VehicleColorHexadecimal = "3a4557" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Metal Stream Metallic", VehicleColorHexadecimal = "7d7f8b" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Precious Metal", VehicleColorHexadecimal = "515560" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Grandeur Grey", VehicleColorHexadecimal = "7a7a7c" },
                    new VehicleColor { VehicleColorCategoryId = 5, VehicleColorName = "Massive Gray", VehicleColorHexadecimal = "767d8a" },

                    // Green
                    new VehicleColor { VehicleColorCategoryId = 6, VehicleColorName = "Land Breeze Green", VehicleColorHexadecimal = "35371e" },
                    new VehicleColor { VehicleColorCategoryId = 6, VehicleColorName = "Greenish Gun Metal", VehicleColorHexadecimal = "206c58" },
                    new VehicleColor { VehicleColorCategoryId = 6, VehicleColorName = "Greenish Gun Metal Mica Metallic", VehicleColorHexadecimal = "4e5b4f" },
                    new VehicleColor { VehicleColorCategoryId = 6, VehicleColorName = "Ever Rest", VehicleColorHexadecimal = "3b4e4f" },
                    new VehicleColor { VehicleColorCategoryId = 6, VehicleColorName = "Moss Green", VehicleColorHexadecimal = "112c23" },

                    // Jade
                    new VehicleColor { VehicleColorCategoryId = 7, VehicleColorName = "Alumina Jade Metallic", VehicleColorHexadecimal = "627564" },

                    // Orange
                    new VehicleColor { VehicleColorCategoryId = 8, VehicleColorName = "Orange Metallic 3", VehicleColorHexadecimal = "932200" },
                    new VehicleColor { VehicleColorCategoryId = 8, VehicleColorName = "Plasma Orange", VehicleColorHexadecimal = "ed4b24" },

                    // Red
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Red 2", VehicleColorHexadecimal = "b40208" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Red Mica", VehicleColorHexadecimal = "800000" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Red Mica Metallic", VehicleColorHexadecimal = "920002" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Red Mica Metallic 2", VehicleColorHexadecimal = "7c0000" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Super Red V", VehicleColorHexadecimal = "d6353c" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Emotional Red", VehicleColorHexadecimal = "770000" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Ignition Red", VehicleColorHexadecimal = "a20000" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Prominence Red", VehicleColorHexadecimal = "d32944" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Dark Red Mica Metallic", VehicleColorHexadecimal = "bb2f34" },
                    new VehicleColor { VehicleColorCategoryId = 9, VehicleColorName = "Blackish Red Mica", VehicleColorHexadecimal = "5d313a" },

                    // Scarlet
                    new VehicleColor { VehicleColorCategoryId = 10, VehicleColorName = "Scarlet SE", VehicleColorHexadecimal = "770000" },

                    // Silver
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Silver Metallic", VehicleColorHexadecimal = "bfbfbf" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Silver Metallic 1", VehicleColorHexadecimal = "cdd5d8" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Silver Metallic 2", VehicleColorHexadecimal = "bfbfbf" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Silver Metallic 4", VehicleColorHexadecimal = "bfbfbf" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Silver Mica Metallic", VehicleColorHexadecimal = "d6d6d6" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Ice Silver Metallic", VehicleColorHexadecimal = "8d99a7" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Splendid Silver", VehicleColorHexadecimal = "f0f0f0" },
                    new VehicleColor { VehicleColorCategoryId = 11, VehicleColorName = "Purplish Silver Mica Metallic", VehicleColorHexadecimal = "5a5a63" },

                    // Turquoise
                    new VehicleColor { VehicleColorCategoryId = 12, VehicleColorName = "Turquoise Mica Metallic", VehicleColorHexadecimal = "034f75" },
                    new VehicleColor { VehicleColorCategoryId = 12, VehicleColorName = "Dark Turquoise SE", VehicleColorHexadecimal = "1e345b" },

                    // White
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "White 1", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "White 2", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "White Metallic", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Super White II", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "White Pearl Mica", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "White Pearl Crystal Shine", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Platinum White Pearl Mica", VehicleColorHexadecimal = "f8f9fa" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Arctic White", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Matte Avalanche White Metallic", VehicleColorHexadecimal = "c0c4c3" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "White Pearl SE", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Crystal White Pearl", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Precious White Pearl", VehicleColorHexadecimal = "ffffff" },
                    new VehicleColor { VehicleColorCategoryId = 13, VehicleColorName = "Luxury Pearl Toning", VehicleColorHexadecimal = "e7e7e7" },

                    // Yellow
                    new VehicleColor { VehicleColorCategoryId = 14, VehicleColorName = "Yellow SE", VehicleColorHexadecimal = "fdbb4d" }
                );

                context.SaveChanges();
            }
        }
    }
}
