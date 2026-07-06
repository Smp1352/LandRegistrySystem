

namespace LandRegistrySystem.Models.Entities;

public class Attachment : BaseEntity
{
    public int? ParcelId { get; set; }

    public Parcel? Parcel { get; set; } = null!;

    public string FileName { get; set; } = "";

    public string FilePath { get; set; } = "";

    public string? ContentType { get; set; }

    public long FileSize { get; set; }
}
