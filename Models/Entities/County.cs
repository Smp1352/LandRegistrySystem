// Models/Entities/County.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities
{
    public class County : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "نام شهرستان")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        [Display(Name = "کد شهرستان")]
        public string? Code { get; set; }

        // کلید خارجی به Province
        public int? ProvinceId { get; set; }
        public virtual Province? Province { get; set; }

        // رابطه یک به چند با Parcel
        public virtual ICollection<Parcel>? Parcels { get; set; }  // ← این مهم است

        // رابطه یک به چند با Village
        public virtual ICollection<Village>? Villages { get; set; }
    }
}