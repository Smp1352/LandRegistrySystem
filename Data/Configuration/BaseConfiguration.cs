// Data/Configuration/BaseConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;  

namespace LandRegistrySystem.Data.Configuration
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity  
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasIndex(x => x.IsDeleted)
                   .HasDatabaseName($"IX_{typeof(TEntity).Name}_IsDeleted");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}