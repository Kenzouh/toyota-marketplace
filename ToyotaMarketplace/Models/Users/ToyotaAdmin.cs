using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyotaMarketplace.Models.Users
{
    public class ToyotaAdmin
    {
        [Key]
        public int ToyotaAdminId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        // Navigation Properties
        public User User { get; set; } // to User
    }
}
