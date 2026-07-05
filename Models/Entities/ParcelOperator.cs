

namespace LandRegistrySystem.Models.Entities;

public class ParcelOperator : BaseEntity
{
    public int ParcelId { get; set; }

    public Parcel Parcel { get; set; } = null!;

    public int PersonId { get; set; }

    public Person Person { get; set; } = null!;

    public string? RelationWithOwner { get; set; }

    public string? OwnershipConfirm { get; set; }
}
