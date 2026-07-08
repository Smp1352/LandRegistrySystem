// Models/Entities/Person.cs
using LandRegistrySystem.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities
{
    public class Person : BaseEntity
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(10)]
        [Required]
        public string? NationalCode { get; set; }

        [MaxLength(15)]
        public string? Mobile { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }         // ✅ جدید

        [MaxLength(50)]
        public string? FatherName { get; set; }

        public DateTime? BirthDate { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }       // ✅ جدید

        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }         // ✅ جدید

        [MaxLength(10)]
        public string? PostalCode { get; set; }    // ✅ جدید

        // روابط
        public virtual ICollection<ParcelOwner>? ParcelOwners { get; set; }
        public virtual ICollection<ParcelOperator>? ParcelOperators { get; set; }
    }
}