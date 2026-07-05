// Models/Entities/Province.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities
{
    public class Province : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "نام استان")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        [Display(Name = "کد استان")]
        public string? Code { get; set; }

        // رابطه یک به چند با Parcel
        public virtual ICollection<Parcel>? Parcels { get; set; }  // ← این مهم است

        // رابطه یک به چند با County
        public virtual ICollection<County>? Counties { get; set; }
    }
}