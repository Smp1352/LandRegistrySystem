// Data/Configuration/ProvinceConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    public class ProvinceConfiguration : BaseConfiguration<Province>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            base.Configure(builder);

            builder.ToTable("Provinces");

            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Code)
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.HasIndex(p => p.Code)
                   .IsUnique()
                   .HasDatabaseName("IX_Province_Code");
        }
    }
}