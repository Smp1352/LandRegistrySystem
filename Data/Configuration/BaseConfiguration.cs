// Data/Configuration/BaseConfiguration.cs
using LandRegistrySystem.Models.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandRegistrySystem.Data.Configuration
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // ==========================================
            // کلید اصلی
            // ==========================================
            builder.HasKey(x => x.Id);

            // ==========================================
            // تاریخ ایجاد
            // ==========================================
            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()")
                   .HasColumnType("datetime2");

            // ==========================================
            // تاریخ ویرایش
            // ==========================================
            builder.Property(x => x.UpdatedAt)
                   .IsRequired(false)
                   .HasColumnType("datetime2");

            // ==========================================
            // Soft Delete
            // ==========================================
            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();

            // ==========================================
            // ایندکس‌ها
            // ==========================================
            builder.HasIndex(x => x.IsDeleted)
                   .HasDatabaseName($"IX_{typeof(TEntity).Name}_IsDeleted");

            builder.HasIndex(x => x.CreatedAt)
                   .HasDatabaseName($"IX_{typeof(TEntity).Name}_CreatedAt");

            // ==========================================
            // فیلتر سراسری
            // ==========================================
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}