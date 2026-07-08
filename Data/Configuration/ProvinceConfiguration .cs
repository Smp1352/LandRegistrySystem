// Data/Configuration/ProvinceConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    /// <summary>
    /// پیکربندی جدول استان‌ها
    /// </summary>
    public class ProvinceConfiguration : BaseConfiguration<Province>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            // ==========================================
            // تنظیمات پایه از BaseConfiguration
            // ==========================================
            base.Configure(builder);

            // ==========================================
            // نام جدول
            // ==========================================
            builder.ToTable("Provinces");

            // ==========================================
            // فیلدها
            // ==========================================

            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasComment("نام استان");

            builder.Property(p => p.Code)
                   .HasMaxLength(10)
                   .IsRequired(false)
                   .HasComment("کد استان");

            // ==========================================
            // ایندکس‌ها
            // ==========================================

            builder.HasIndex(p => p.Code)
                   .IsUnique()
                   .HasDatabaseName("IX_Province_Code");

            builder.HasIndex(p => p.Name)
                   .HasDatabaseName("IX_Province_Name");

            // ==========================================
            // روابط
            // ==========================================

            // رابطه یک به چند با County
            builder.HasMany(p => p.Counties)
                   .WithOne(c => c.Province)
                   .HasForeignKey(c => c.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Counties_Provinces");

            // رابطه یک به چند با Parcel
            builder.HasMany(p => p.Parcels)
                   .WithOne(pr => pr.Province)
                   .HasForeignKey(pr => pr.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Parcels_Provinces");
        }
    }
}