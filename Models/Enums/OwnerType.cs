// Models/Enums/OwnerType.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Enums
{
    public enum OwnerType
    {
        [Display(Name = "حقیقی")]
        Natural,
        [Display(Name = "حقوقی")]
        Legal
    }
}

// Models/Enums/OwnershipUnit.cs
namespace LandRegistrySystem.Models.Enums
{
    public enum OwnershipUnit
    {
        [Display(Name = "عرصه")]
        Land,
        [Display(Name = "اعیان")]
        Building,
        [Display(Name = "عرصه و اعیان")]
        LandAndBuilding
    }
}