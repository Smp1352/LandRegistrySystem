// Data/Configuration/VillageConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    /// <summary>
    /// پیکربندی جدول آبادی‌ها (روستاها)
    /// </summary>
    public class VillageConfiguration : BaseConfiguration<Village>
    {
        public override void Configure(EntityTypeBuilder<Village> builder)
        {
            // ==========================================
            // تنظیمات پایه از BaseConfiguration
            // ==========================================
            base.Configure(builder);

            // ==========================================
            // نام جدول
            // ==========================================
            builder.ToTable("Villages");

            // ==========================================
            // فیلدها
            // ==========================================

            builder.Property(v => v.Name)
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasComment("نام آبادی");

            builder.Property(v => v.Code)
                   .HasMaxLength(10)
                   .IsRequired(false)
                   .HasComment("کد آبادی");

            // کلید خارجی به County
            builder.Property(v => v.CountyId)
                   .IsRequired(false)
                   .HasComment("شناسه شهرستان");

            // ==========================================
            // ایندکس‌ها
            // ==========================================

            builder.HasIndex(v => v.Code)
                   .IsUnique()
                   .HasDatabaseName("IX_Village_Code");

            builder.HasIndex(v => v.Name)
                   .HasDatabaseName("IX_Village_Name");

            builder.HasIndex(v => v.CountyId)
                   .HasDatabaseName("IX_Village_CountyId");

            // ایندکس ترکیبی
            builder.HasIndex(v => new { v.CountyId, v.Name })
                   .HasDatabaseName("IX_Village_CountyId_Name");

            // ==========================================
            // روابط
            // ==========================================

            // رابطه با County
            builder.HasOne(v => v.County)
                   .WithMany(c => c.Villages)
                   .HasForeignKey(v => v.CountyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Villages_Counties");

            // رابطه یک به چند با Parcel
            builder.HasMany(v => v.Parcels)
                   .WithOne(p => p.Village)
                   .HasForeignKey(p => p.VillageId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Parcels_Villages");
        }
    }
}