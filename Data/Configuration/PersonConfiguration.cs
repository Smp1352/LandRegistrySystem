// Data/Configuration/PersonConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    /// <summary>
    /// پیکربندی جدول اشخاص
    /// </summary>
    public class PersonConfiguration : BaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            // ==========================================
            // تنظیمات پایه از BaseConfiguration
            // ==========================================
            base.Configure(builder);

            // ==========================================
            // نام جدول
            // ==========================================
            builder.ToTable("Persons");

            // ==========================================
            // فیلدها
            // ==========================================

            builder.Property(p => p.FirstName)
                   .HasMaxLength(50)
                   .IsRequired(false)
                   .HasComment("نام");

            builder.Property(p => p.LastName)
                   .HasMaxLength(50)
                   .IsRequired(false)
                   .HasComment("نام خانوادگی");

            builder.Property(p => p.NationalCode)
                   .HasMaxLength(10)
                   .IsRequired()
                   .HasComment("کدملی");

            builder.Property(p => p.Mobile)
                   .HasMaxLength(15)
                   .IsRequired(false)
                   .HasComment("شماره همراه");

            builder.Property(p => p.Phone)
                   .HasMaxLength(15)
                   .IsRequired(false)
                   .HasComment("شماره تلفن ثابت");

            builder.Property(p => p.FatherName)
                   .HasMaxLength(50)
                   .IsRequired(false)
                   .HasComment("نام پدر");

            builder.Property(p => p.BirthDate)
                   .HasColumnType("date")
                   .IsRequired(false)
                   .HasComment("تاریخ تولد");

            builder.Property(p => p.Address)
                   .HasMaxLength(500)
                   .IsRequired(false)
                   .HasComment("آدرس");

            builder.Property(p => p.Email)
                   .HasMaxLength(50)
                   .IsRequired(false)
                   .HasComment("ایمیل");

            builder.Property(p => p.PostalCode)
                   .HasMaxLength(10)
                   .IsRequired(false)
                   .HasComment("کد پستی");

            // ==========================================
            // ایندکس‌ها
            // ==========================================

            builder.HasIndex(p => p.NationalCode)
                   .IsUnique()
                   .HasDatabaseName("IX_Person_NationalCode");

            builder.HasIndex(p => p.FirstName)
                   .HasDatabaseName("IX_Person_FirstName");

            builder.HasIndex(p => p.LastName)
                   .HasDatabaseName("IX_Person_LastName");

            builder.HasIndex(p => p.Mobile)
                   .HasDatabaseName("IX_Person_Mobile");

            // ایندکس ترکیبی
            builder.HasIndex(p => new { p.FirstName, p.LastName })
                   .HasDatabaseName("IX_Person_FullName");

            // ==========================================
            // روابط
            // ==========================================

            // رابطه یک به چند با ParcelOwner
            builder.HasMany(p => p.ParcelOwners)
                   .WithOne(po => po.Person)
                   .HasForeignKey(po => po.PersonId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_ParcelOwners_Persons");

            // رابطه یک به چند با ParcelOperator
            builder.HasMany(p => p.ParcelOperators)
                   .WithOne(po => po.Person)
                   .HasForeignKey(po => po.PersonId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_ParcelOperators_Persons");
        }
    }
}