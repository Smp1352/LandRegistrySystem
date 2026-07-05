
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities;

public class Person : BaseEntity
{
    [MaxLength(50)]
    public string FirstName { get; set; } = "";

    [MaxLength(50)]
    public string LastName { get; set; } = "";

    [MaxLength(50)]
    public string? FatherName { get; set; }

    [MaxLength(10)]
    public string NationalCode { get; set; } = "";

    [MaxLength(15)]
    public string? Mobile { get; set; }

    public DateTime? BirthDate { get; set; }

    public ICollection<ParcelOwner> OwnedParcels { get; set; } = new List<ParcelOwner>();

    public ICollection<ParcelOperator> OperatedParcels { get; set; } = new List<ParcelOperator>();
}