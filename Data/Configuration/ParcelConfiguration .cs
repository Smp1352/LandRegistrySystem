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
            // فراخوانی تنظیمات پایه
            base.Configure(builder);

            // تنظیم نام جدول
            builder.ToTable("Parcels");

            // ===== مشخصات عمومی =====
            builder.Property(p => p.PersianName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.EnglishName)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(p => p.Definition)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.Property(p => p.FeatureClass)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(p => p.FeatureType)
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(p => p.Dimension)
                   .HasMaxLength(10)
                   .IsRequired(false);

            // ===== اطلاعات توصیفی =====
            builder.Property(p => p.ParcelCode)
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(p => p.PostalCode)
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(p => p.Area)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(false);

            // ===== اطلاعات مکانی =====
            builder.Property(p => p.ProvinceName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.Shahrestan)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.AbadiName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // ===== اطلاعات ثبتی =====
            builder.Property(p => p.NahiyeSabti)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.PlakName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // ===== اطلاعات کاربری =====
            builder.Property(p => p.CurrentOperationLandUse)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.CropsType)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // ===== اطلاعات مالک =====
            builder.Property(p => p.OwnerType)
                   .HasMaxLength(5)
                   .IsRequired(false);

            builder.Property(p => p.ShorakaTedad)
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(p => p.OwnerName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OwnerLastName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OwnerNationalCode)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OwnerMobile)
                   .HasMaxLength(15)
                   .IsRequired(false);

            builder.Property(p => p.OwnerFatherName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OwnerBirthday)
                   .HasColumnType("date")
                   .IsRequired(false);

            builder.Property(p => p.OwnershipUnit)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OwnershipQuantity)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(false);

            builder.Property(p => p.OwnershipProof)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // ===== اطلاعات بهره‌بردار =====
            builder.Property(p => p.OperatorName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OperatorLastName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OperatorNationalCode)
                   .HasMaxLength(15)
                   .IsRequired(false);

            builder.Property(p => p.OperatorMobile)
                   .HasMaxLength(15)
                   .IsRequired(false);

            builder.Property(p => p.OperatorFatherName)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OperatorBirthday)
                   .HasColumnType("date")
                   .IsRequired(false);

            builder.Property(p => p.RelationOwnerOperator)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.OwnershipConfirm)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // ===== سایر اطلاعات =====
            builder.Property(p => p.ChangeLandUse)
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(p => p.SanadMafroozi)
                   .HasMaxLength(5)
                   .IsRequired(false);

            builder.Property(p => p.Description)
                   .HasMaxLength(254)
                   .IsRequired(false);

            // ===== ایندکس‌ها =====
            builder.HasIndex(p => p.ParcelCode)
                   .HasDatabaseName("IX_ParcelCode");

            builder.HasIndex(p => p.UniqueParcelCode)
                   .HasDatabaseName("IX_UniqueParcelCode");

            builder.HasIndex(p => p.OwnerNationalCode)
                   .HasDatabaseName("IX_OwnerNationalCode");

            builder.HasIndex(p => p.ProvinceName)
                   .HasDatabaseName("IX_ProvinceName");

            // ===== روابط =====
            builder.HasOne(p => p.Province)
                   .WithMany(pr => pr.Parcels)
                   .HasForeignKey(p => p.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.County)
                   .WithMany(c => c.Parcels)
                   .HasForeignKey(p => p.CountyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Village)
                   .WithMany(v => v.Parcels)
                   .HasForeignKey(p => p.VillageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}