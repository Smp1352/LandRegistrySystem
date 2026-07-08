// Data/Configuration/CountyConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    /// <summary>
    /// پیکربندی جدول شهرستان‌ها
    /// </summary>
    public class CountyConfiguration : BaseConfiguration<County>
    {
        public override void Configure(EntityTypeBuilder<County> builder)
        {
            // ==========================================
            // تنظیمات پایه از BaseConfiguration
            // ==========================================
            base.Configure(builder);

            // ==========================================
            // نام جدول
            // ==========================================
            builder.ToTable("Counties");

            // ==========================================
            // فیلدها
            // ==========================================

            builder.Property(c => c.Name)
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasComment("نام شهرستان");

            builder.Property(c => c.Code)
                   .HasMaxLength(10)
                   .IsRequired(false)
                   .HasComment("کد شهرستان");

            // کلید خارجی به Province
            builder.Property(c => c.ProvinceId)
                   .IsRequired(false)
                   .HasComment("شناسه استان");

            // ==========================================
            // ایندکس‌ها
            // ==========================================

            builder.HasIndex(c => c.Code)
                   .IsUnique()
                   .HasDatabaseName("IX_County_Code");

            builder.HasIndex(c => c.Name)
                   .HasDatabaseName("IX_County_Name");

            builder.HasIndex(c => c.ProvinceId)
                   .HasDatabaseName("IX_County_ProvinceId");

            // ایندکس ترکیبی
            builder.HasIndex(c => new { c.ProvinceId, c.Name })
                   .HasDatabaseName("IX_County_ProvinceId_Name");

            // ==========================================
            // روابط
            // ==========================================

            // رابطه با Province
            builder.HasOne(c => c.Province)
                   .WithMany(p => p.Counties)
                   .HasForeignKey(c => c.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Counties_Provinces");

            // رابطه یک به چند با Village
            builder.HasMany(c => c.Villages)
                   .WithOne(v => v.County)
                   .HasForeignKey(v => v.CountyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Villages_Counties");

            // رابطه یک به چند با Parcel
            builder.HasMany(c => c.Parcels)
                   .WithOne(p => p.County)
                   .HasForeignKey(p => p.CountyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Parcels_Counties");
        }
    }
}