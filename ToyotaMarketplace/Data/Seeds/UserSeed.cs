using ToyotaMarketplace.Areas.Data;
using ToyotaMarketplace.Models.Users;

namespace ToyotaMarketplace.Data.Seeds
{
    public static class UserSeed
    {

        // Helper to create a user with a hashed password.
        private static User CreateUser(string Username, string UserFirstName, string UserLastName,
                                            string Email, string plainPassword, DateTime? registerDate = null)
        {
            return new User
            {
                Username = Username,
                UserFirstName = UserFirstName,
                UserLastName = UserLastName,
                Email = Email,
                Password = BCrypt.Net.BCrypt.HashPassword(plainPassword), // Hashing
                RegisterDate = registerDate ?? DateTime.Now
            };
        }

        public static void Seed(ApplicationDbContext context)
        {

            if (!context.Users.Any())
            {
                context.Users.AddRange(

                    CreateUser("Kenzou", "Ken", "Di", "kenzo8593522882@gmail.com", "TestPassword123!", registerDate: DateTime.Now)

                );

                context.SaveChanges();
            }
        }
    }
}