// Models/Enums/LandUseType.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Enums
{
    public enum LandUseType
    {
        [Display(Name = "زراعت آبی")]
        IrrigatedFarming,

        [Display(Name = "زراعت دیم")]
        DryFarming,

        [Display(Name = "باغ آبی")]
        IrrigatedOrchard,

        [Display(Name = "باغ دیم")]
        DryOrchard,

        [Display(Name = "نهالستان / قلمستان")]
        Nursery,

        [Display(Name = "پرورش طویل")]
        Livestock,

        [Display(Name = "آبی‌پوری")]
        Aquaculture,

        [Display(Name = "صنایع تبدیلی و تکمیلی")]
        AgroIndustry,

        [Display(Name = "نوع محصول محصوالت")]
        OtherProducts
    }
}