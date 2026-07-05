// Models/Entities/Village.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities
{
    public class Village : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "نام آبادی")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        [Display(Name = "کد آبادی")]
        public string? Code { get; set; }

        // کلید خارجی به County
        public int? CountyId { get; set; }
        public virtual County? County { get; set; }

        // رابطه یک به چند با Parcel
        public virtual ICollection<Parcel>? Parcels { get; set; }  // ← این مهم است
    }
}