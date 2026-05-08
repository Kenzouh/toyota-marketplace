using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Users;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class ToyotaAdminSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.ToyotaAdmins.Any())
            {
                context.ToyotaAdmins.AddRange(
                
                    new ToyotaAdmin { UserId = 1 }
                );

                context.SaveChanges();
            }
        }
    }
}
