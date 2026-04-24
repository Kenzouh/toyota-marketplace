using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Models.Users;

namespace ToyotaCars.Areas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // DB sets for each model
        public DbSet<User> Users { get; set; }
        public DbSet<ToyotaAdmin> ToyotaAdmins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // u (User) | ta (ToyotaAdmin)
            // (1:1) User -> ToyotaAdmin
            modelBuilder.Entity<User>()
                .HasOne(u => u.ToyotaAdmin) // Each user has one admin.
                .WithOne(ta => ta.User) // Admin linked to 1 user.
                .HasForeignKey<ToyotaAdmin>(ta => ta.UserId);

        }

    }
}