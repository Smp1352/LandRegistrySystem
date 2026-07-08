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

        // ==========================================
        // DbSet‌ها
        // ==========================================

        public DbSet<Province> Provinces { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelOwner> ParcelOwners { get; set; }
        public DbSet<ParcelOperator> ParcelOperators { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<CropType> CropTypes { get; set; }
        public DbSet<LandUse> LandUses { get; set; }

        // ==========================================
        // اعمال Configurations
        // ==========================================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // اعمال تمام Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}