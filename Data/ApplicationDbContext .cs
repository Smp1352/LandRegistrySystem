// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CropType> CropTypes { get; set; }
        public DbSet<LandUse> LandUses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ این خط همه Configurationها را به صورت خودکار اعمال می‌کند
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}