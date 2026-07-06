

namespace LandRegistrySystem.Models.Entities;

public class ParcelOwner : BaseEntity
{
    public int? PersonId { get; set; } // ← با افزودن ? قابل‌تهی شد
    public virtual Person? Person { get; set; } // ← با افزودن ? قابل‌تهی شد
    public int? ParcelId { get; set; }
   
    public Parcel? Parcel { get; set; } = null!;
     
    public string? OwnershipUnit { get; set; }

    public double OwnershipQuantity { get; set; }

    public string? OwnershipProof { get; set; }
}