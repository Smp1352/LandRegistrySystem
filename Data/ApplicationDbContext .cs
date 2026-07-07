// Data/ApplicationDbContext.cs
using LandRegistrySystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LandRegistrySystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ===== DbSet‌های اصلی =====
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<CropType> CropTypes { get; set; }
        public DbSet<LandUse> LandUses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        // ===== DbSet‌های رابط Many-to-Many =====
        public DbSet<ParcelOwner> ParcelOwners { get; set; }      // ✅ اضافه کنید
        public DbSet<ParcelOperator> ParcelOperators { get; set; } // ✅ اضافه کنید

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // اعمال تمام Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}