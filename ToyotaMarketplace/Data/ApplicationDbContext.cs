using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Models.Users;
using ToyotaMarketplace.Models.Vehicles;

namespace ToyotaMarketplace.Areas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // DB sets of each model (for DB)
        // Template: publicDbSet<Model/.cs file> TblName in DB { get; set;}
        
        // Users Category
        public DbSet<User> Users { get; set; }
        public DbSet<ToyotaAdmin> ToyotaAdmins { get; set; }

        // Vehicles Category
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleColor> VehicleColors { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleColorCategory> VehicleColorCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===============================  Users =============================== 

            // u (User) | ta (ToyotaAdmin)
            // (1:1) User -> ToyotaAdmin
            modelBuilder.Entity<User>()
                .HasOne(u => u.ToyotaAdmin) // Each user has one admin.
                .WithOne(ta => ta.User) // Admin linked to 1 user.
                .HasForeignKey<ToyotaAdmin>(ta => ta.UserId);

            // =============================== Vehicles ===============================

            // N:1 Vehicle -> ToyotaAdmin
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.ToyotaAdmin)
                .WithMany(ta => ta.Vehicles)
                .HasForeignKey(v => v.ToyotaAdminId);

            // N:1 Vehicle -> VehicleColor
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleColor)
                .WithMany(vc => vc.Vehicles)
                .HasForeignKey(v => v.VehicleColorId);

            // N:1 Vehicle -> VehicleModel
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleModel)
                .WithMany(vm => vm.Vehicles)
                .HasForeignKey(v => v.VehicleModelId);

            // N:1 VehicleModel -> VehicleType
            modelBuilder.Entity<VehicleModel>()
                .HasOne(vm => vm.VehicleType)
                .WithMany(vt => vt.VehicleModels)
                .HasForeignKey(vm => vm.VehicleTypeId);

            // N:1 VehicleColor -> VehicleColorCategory
            modelBuilder.Entity<VehicleColor>()
               .HasOne(vc => vc.VehicleColorCategory)
               .WithMany(vcc => vcc.VehicleColors)
               .HasForeignKey(vc => vc.VehicleColorCategoryId);
        }

    }
}