

namespace LandRegistrySystem.Models.Entities;

public class ParcelOwner : BaseEntity
{
    public int? ParcelId { get; set; }
   
    public Parcel? Parcel { get; set; } = null!;

    public int PersonId { get; set; }

    public Person Person { get; set; } = null!;

    public string? OwnershipUnit { get; set; }

    public double OwnershipQuantity { get; set; }

    public string? OwnershipProof { get; set; }
}