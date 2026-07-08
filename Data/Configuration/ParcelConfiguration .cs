// Data/Configuration/ParcelConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    public class ParcelConfiguration : BaseConfiguration<Parcel>
    {
        public override void Configure(EntityTypeBuilder<Parcel> builder)
        {
            // تنظیمات پایه
            base.Configure(builder);

            builder.ToTable("Parcels");

            // ==========================================
            // ✅ روابط - اینجا باید باشد، نه در BaseConfiguration
            // ==========================================

            // رابطه با Province
            builder.HasOne(p => p.Province)
                   .WithMany(pr => pr.Parcels)
                   .HasForeignKey(p => p.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Parcels_Provinces");

            // رابطه با County
            builder.HasOne(p => p.County)
                   .WithMany(c => c.Parcels)
                   .HasForeignKey(p => p.CountyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Parcels_Counties");

            // رابطه با Village
            builder.HasOne(p => p.Village)
                   .WithMany(v => v.Parcels)
                   .HasForeignKey(p => p.VillageId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Parcels_Villages");

            // ==========================================
            // فیلدها
            // ==========================================

            builder.Property(p => p.ParcelCode)
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(p => p.PersianName)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(p => p.EnglishName)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(p => p.Area)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(false);

            // ==========================================
            // ایندکس‌ها
            // ==========================================

            builder.HasIndex(p => p.ParcelCode)
                   .HasDatabaseName("IX_Parcel_ParcelCode");

            builder.HasIndex(p => p.ProvinceId)
                   .HasDatabaseName("IX_Parcel_ProvinceId");

            builder.HasIndex(p => p.CountyId)
                   .HasDatabaseName("IX_Parcel_CountyId");

            builder.HasIndex(p => p.VillageId)
                   .HasDatabaseName("IX_Parcel_VillageId");

            builder.HasIndex(p => p.OwnerNationalCode)
                   .HasDatabaseName("IX_Parcel_OwnerNationalCode");
        }
    }
}