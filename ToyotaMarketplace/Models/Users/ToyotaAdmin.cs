using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToyotaMarketplace.Models.Vehicles;

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

        // One-to-many
        public ICollection<Vehicle> Vehicles { get; set; } // To Vehicles

    }
}
