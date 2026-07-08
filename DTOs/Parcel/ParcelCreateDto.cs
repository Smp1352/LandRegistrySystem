// DTOs/Parcel/ParcelCreateDto.cs
using System.ComponentModel.DataAnnotations;
using LandRegistrySystem.Models.Enums;

namespace LandRegistrySystem.DTOs.Parcel
{
    public class ParcelCreateDto
    {
        // ==========================================
        // اطلاعات توصیفی TDB
        // ==========================================

        [Display(Name = "مختصات X مرکز قطعه")]
        public long? X { get; set; }

        [Display(Name = "مختصات Y مرکز قطعه")]
        public long? Y { get; set; }

        [Display(Name = "زون مرکز قطعه")]
        public long? Zone { get; set; }

        [Display(Name = "کد قطعه")]
        [MaxLength(20)]
        public string? ParcelCode { get; set; }

        [Display(Name = "کدپستی قطعه")]
        [MaxLength(20)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدپستی باید 10 رقم باشد")]
        public string? PostalCode { get; set; }

        [Display(Name = "مساحت (مترمربع)")]
        [Range(0, double.MaxValue, ErrorMessage = "مساحت باید عدد مثبت باشد")]
        public decimal? Area { get; set; }

        [Display(Name = "کد شناسه یکتای قطعه")]
        public double? UniqueParcelCode { get; set; }

        // ==========================================
        // اطلاعات مکانی
        // ==========================================

        [Display(Name = "استان")]
        [MaxLength(50)]
        public string? Province { get; set; }

        [Display(Name = "شهرستان")]
        [MaxLength(50)]
        public string? Shahrestan { get; set; }

        [Display(Name = "نام آبادی")]
        [MaxLength(50)]
        public string? AbadiName { get; set; }

        [Display(Name = "کد آبادی")]
        public int? AbadiCode { get; set; }

        // ==========================================
        // اطلاعات ثبتی
        // ==========================================

        [Display(Name = "ناحیه ثبتی")]
        [MaxLength(50)]
        public string? NahiyeSabti { get; set; }

        [Display(Name = "نام پلاک ثبتی")]
        [MaxLength(50)]
        public string? PlakName { get; set; }

        [Display(Name = "شماره پلاک اصلی")]
        public int? PlakAsli { get; set; }

        [Display(Name = "شماره پلاک فرعی")]
        public int? PlakFarei { get; set; }

        [Display(Name = "بخش ثبتی")]
        public int? BakhshSabti { get; set; }

        // ==========================================
        // اطلاعات کاربری
        // ==========================================

        [Display(Name = "بهره برداری فعلی قطعه")]
        [MaxLength(50)]
        public string? CurrentOperationLandUse { get; set; }

        [Display(Name = "نوع محصول")]
        [MaxLength(50)]
        public string? CropsType { get; set; }

        // ==========================================
        // اطلاعات مالک (متصرف)
        // ==========================================

        [Display(Name = "کدملی مالک")]
        [MaxLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدملی باید 10 رقم باشد")]
        public string? OwnerNationalCode { get; set; }

        [Display(Name = "نام مالک")]
        [MaxLength(100)]
        public string? OwnerName { get; set; }

        [Display(Name = "نام خانوادگی مالک")]
        [MaxLength(100)]
        public string? OwnerLastName { get; set; }

        [Display(Name = "شماره همراه مالک")]
        [MaxLength(100)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه باید با 09 شروع شود و 11 رقم باشد")]
        public string? OwnerMobile { get; set; }

        [Display(Name = "نام پدر مالک")]
        [MaxLength(50)]
        public string? OwnerFatherName { get; set; }

        [Display(Name = "تاریخ تولد مالک")]
        [RegularExpression(@"^[1-4]\d{3}/(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])$",
            ErrorMessage = "فرمت تاریخ باید yyyy/MM/dd باشد")]
        public string? OwnerBirthdayPersian { get; set; }

        [Display(Name = "نوع متصرف")]
        public OwnerType? OwnerType { get; set; }

        // ✅ اضافه کنید
        [Display(Name = "تعداد شرکا")]
        [MaxLength(10)]
        [RegularExpression(@"^\d+$", ErrorMessage = "تعداد شرکا باید عدد باشد")]
        public string? ShorakaTedad { get; set; }

        [Display(Name = "نوع مالکیت")]
        public OwnershipUnit? OwnershipUnit { get; set; }

        [Display(Name = "تعداد سهم مالکیت")]
        [Range(0, double.MaxValue, ErrorMessage = "تعداد سهم باید عدد مثبت باشد")]
        public double? OwnershipQuantity { get; set; }

        [Display(Name = "ادله و امارات مالکیت")]
        [MaxLength(500)]
        public string? OwnershipProof { get; set; }

        // ==========================================
        // اطلاعات بهره‌بردار
        // ==========================================

        [Display(Name = "کدملی بهره‌بردار")]
        [MaxLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدملی باید 10 رقم باشد")]
        public string? OperatorNationalCode { get; set; }

        [Display(Name = "نام بهره‌بردار")]
        [MaxLength(100)]
        public string? OperatorName { get; set; }

        [Display(Name = "نام خانوادگی بهره‌بردار")]
        [MaxLength(100)]
        public string? OperatorLastName { get; set; }

        [Display(Name = "شماره همراه بهره‌بردار")]
        [MaxLength(15)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه باید با 09 شروع شود و 11 رقم باشد")]
        public string? OperatorMobile { get; set; }

        [Display(Name = "نام پدر بهره‌بردار")]
        [MaxLength(100)]
        public string? OperatorFatherName { get; set; }

        [Display(Name = "تاریخ تولد بهره‌بردار")]
        [RegularExpression(@"^[1-4]\d{3}/(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])$",
            ErrorMessage = "فرمت تاریخ باید yyyy/MM/dd باشد")]
        public string? OperatorBirthdayPersian { get; set; }

        [Display(Name = "رابطه حقوقی بهره‌بردار با مالک")]
        [MaxLength(100)]
        public string? RelationOwnerOperator { get; set; }

        [Display(Name = "روش احراز تصرفات")]
        [MaxLength(50)]
        public string? OwnershipConfirm { get; set; }

        // ==========================================
        // سایر اطلاعات
        // ==========================================

        [Display(Name = "کاربری های غیرکشاورزی")]
        [MaxLength(10)]
        public string? ChangeLandUse { get; set; }

        [Display(Name = "سند مفروزی دارد یا خیر")]
        [MaxLength(5)]
        public string? SanadMafroozi { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(254)]
        public string? Description { get; set; }
    }
}