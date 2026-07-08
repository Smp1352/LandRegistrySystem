// Models/Enums/OwnerType.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Enums
{
    public enum OwnerType
    {
        [Display(Name = "حقیقی")]
        Natural = 1,

        [Display(Name = "حقوقی")]
        Legal = 2
    }
}