// Data/Configuration/PersonConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Configuration
{
    public class PersonConfiguration : BaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.ToTable("Persons");

            builder.Property(p => p.FirstName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.LastName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.NationalCode)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(p => p.Mobile)
                   .HasMaxLength(15)
                   .IsRequired(false);

            builder.HasIndex(p => p.NationalCode)
                   .IsUnique()
                   .HasDatabaseName("IX_Person_NationalCode");
        }
    }
}