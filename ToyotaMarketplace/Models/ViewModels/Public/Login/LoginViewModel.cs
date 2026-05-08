using System.ComponentModel.DataAnnotations;

namespace ToyotaMarketplace.Models.ViewModels.Public.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
