// Models/Enums/OwnershipUnit.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Enums
{
    public enum OwnershipUnit
    {
        [Display(Name = "عرصه")]
        Land = 1,

        [Display(Name = "اعیان")]
        Building = 2,

        [Display(Name = "عرصه و اعیان")]
        LandAndBuilding = 3
    }
}