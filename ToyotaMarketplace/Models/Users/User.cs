using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string UserFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string UserLastName { get; set; }
        [Required(ErrorMessage = "Passwored is required.")]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        // Navigation Properties to x Table
        public ToyotaAdmin ToyotaAdmin { get; set; } // to ToyotaAdmin
    }
}
