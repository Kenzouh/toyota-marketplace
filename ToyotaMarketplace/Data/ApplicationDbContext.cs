using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using ToyotaMarketplace.Models.Users;
using ToyotaMarketplace.Models.Vehicles;
using ToyotaMarketplace.Models.Vehicles.Specs;

namespace ToyotaMarketplace.Areas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // DB sets of each model (for DB)
        // Template: publicDbSet<Model/.cs file> TblName in DB { get; set;}
        // If DbSets aren't declared, when you create a migration, you don't create anything.
        
        // Users Category
        public DbSet<User> Users { get; set; }
        public DbSet<ToyotaAdmin> ToyotaAdmins { get; set; }

        // Vehicles Category
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleColor> VehicleColors { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleColorCategory> VehicleColorCategories { get; set; }

        // Vehicle Specifications
        public DbSet<VehicleSpec> VehicleSpecs { get; set; }

        public DbSet<DriveMode> DriveModes { get; set; }

        public DbSet<VehiclePerformanceDriveMode> VehiclePerformanceDriveModes { get; set; } // Join Table

        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<BatteryType> BatteryTypes { get; set; }
        public DbSet<SteeringSystem> SteeringSystems { get; set; }
        public DbSet<SteeringType> SteeringTypes { get; set; }
        public DbSet<PowerSteeringType> PowerSteeringTypes { get; set; }
        public DbSet<BrakeType> BrakeTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<VehiclePerformance> VehiclePerformances { get; set; }
        public DbSet<VehicleTechnical> VehicleTechnicals { get; set; }
        public DbSet<VehicleDimensionFuel> VehicleDimensionFuels { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }

        public DbSet<PowerTrain> PowerTrains { get; set; }

        
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


            // ------------------------------------------------------

            // N:N (Explicit Join)
            modelBuilder.Entity<VehiclePerformanceDriveMode>()
                .HasKey(vpdm => new { vpdm.PerformanceId, vpdm.DriveModeId });

            // 1:N VehiclePerformanceDriveMode -> VehiclePerformance
            modelBuilder.Entity<VehiclePerformanceDriveMode>()
                .HasOne(vpdm => vpdm.VehiclePerformance)
                .WithMany(vp => vp.VehiclePerformanceDriveModes)
                .HasForeignKey(vpdm => vpdm.PerformanceId);

            // 1:N VehiclePerformanceDriveMode -> DriveMode
            modelBuilder.Entity<VehiclePerformanceDriveMode>()
                .HasOne(vpdm => vpdm.DriveMode)
                .WithMany(dm => dm.VehiclePerformanceDriveModes)
                .HasForeignKey(vpdm => vpdm.DriveModeId);

            // VehicleSpec -> VehiclePerformance (optional FK)
            modelBuilder.Entity<VehicleSpec>()
                .HasOne(vs => vs.VehiclePerformance)
                .WithOne(vp => vp.VehicleSpec)
                .HasForeignKey<VehicleSpec>(vs => vs.PerformanceId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade issues.

            // ---

            // 1:1 Vehicle -> VehicleSpec
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleSpec)
                .WithOne(vs => vs.Vehicle)
                .HasForeignKey<VehicleSpec>(v => v.VehicleSpecId);

            // 1:1 VehicleSpec -> VehiclePerformance
            modelBuilder.Entity<VehicleSpec>()
                .HasOne(vs => vs.VehiclePerformance)
                .WithOne(vp => vp.VehicleSpec)
                .HasForeignKey<VehiclePerformance>(vs => vs.PerformanceId);

            // 1:1 VehicleSpec -> VehicleTechnical
            modelBuilder.Entity<VehicleSpec>()
                .HasOne(vs => vs.VehicleTechnical)
                .WithOne(vt => vt.VehicleSpec)
                .HasForeignKey<VehicleTechnical>(vs => vs.TechnicalId);

            // 1:1 VehicleSpec -> VehicleDimensionFuel
            modelBuilder.Entity<VehicleSpec>()
                .HasOne(vs => vs.VehicleDimensionFuel)
                .WithOne(vdf => vdf.VehicleSpec)
                .HasForeignKey<VehicleDimensionFuel>(vs => vs.DimensionFuelId);

            // 1:1 VehicleSpec -> VehicleFeature
            modelBuilder.Entity<VehicleSpec>()
                .HasOne(vs => vs.VehicleFeature)
                .WithOne(vf => vf.VehicleSpec)
                .HasForeignKey<VehicleFeature>(vs => vs.FeatureId);

            // ---

            // 1:N Vehile -> PowerTrain
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.PowerTrain)
                .WithMany(pt => pt.Vehicles)
                .HasForeignKey(v => v.PowerTrainId);

            // ------------------------------------------------------

            // 1:N VehicleTechnical -> BatteryType
            modelBuilder.Entity<VehicleTechnical>()
                .HasOne(vt => vt.BatteryType)
                .WithMany(bt => bt.VehicleTechnicals)
                .HasForeignKey(vt => vt.TechnicalId);

            // 1:N VehicleTechnical -> SteeringSystem
            modelBuilder.Entity<VehicleTechnical>()
                .HasOne(vt => vt.SteeringSystem)
                .WithMany(ss => ss.VehicleTechnicals)
                .HasForeignKey(vt => vt.SteeringSystemId);

            // 1:N VehicleTechnical -> SteeringType
            modelBuilder.Entity<VehicleTechnical>()
                .HasOne(vt => vt.SteeringType)
                .WithMany(st => st.VehicleTechnicals)
                .HasForeignKey(vt => vt.SteeringTypeId);

            // 1:N VehicleTechnical -> PowerSteeringType
            modelBuilder.Entity<VehicleTechnical>()
                .HasOne(vt => vt.PowerSteeringType)
                .WithMany(pst => pst.VehicleTechnicals)
                .HasForeignKey(vt => vt.PowerSteeringTypeId);

            // 1:N VehicleTechnical -> BrakeType
            modelBuilder.Entity<VehicleTechnical>()
                .HasOne(vt => vt.BrakeType)
                .WithMany(bt => bt.VehicleTechnicals)
                .HasForeignKey(vt => vt.BrakeTypeId);
        }
    }
}