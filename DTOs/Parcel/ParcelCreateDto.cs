// DTOs/Parcel/ParcelCreateDto.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.DTOs.Parcel
{
    public class ParcelCreateDto
    {
        // ==========================================
        // مشخصات عمومی
        // ==========================================

        [Display(Name = "نام عارضه (فارسی)")]
        [Required(ErrorMessage = "نام فارسی عارضه الزامی است")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کاراکتر")]
        public string PersianName { get; set; } = "حد مالکیت";

        [Display(Name = "نام عارضه (انگلیسی)")]
        [MaxLength(100)]
        public string? EnglishName { get; set; } = "Ownership_Boundary_A";

        [Display(Name = "تعریف عارضه")]
        [MaxLength(500)]
        public string? Definition { get; set; } = "محدوده قطعه دارای نقشه حدنگار اراضی کشاورزی توسط امور اراضی برای استفاده در اجرای تبصره 3 ماده 10 قانون الزام به ثبت رسمی معاملات اموال غیر منقول";

        [Display(Name = "کلاس عارضه")]
        [MaxLength(100)]
        public string? FeatureClass { get; set; } = "محدوده قطعه کشاورزی";

        [Display(Name = "نوع عارضه")]
        public string? FeatureType { get; set; } = "سطحی";

        [Display(Name = "بعد")]
        public string? Dimension { get; set; } = "2D";

        // ==========================================
        // اطلاعات توصیفی - TDB (فایل Shape)
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
        // اطلاعات کاربری و بهره‌برداری
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

        [Display(Name = "نوع متصرف")]
        [MaxLength(5)]
        public string? OwnerType { get; set; }

        [Display(Name = "تعداد شرکا")]
        [MaxLength(10)]
        public string? ShorakaTedad { get; set; }

        [Display(Name = "نام متصرف")]
        [MaxLength(50)]
        public string? OwnerName { get; set; }

        [Display(Name = "نام خانوادگی متصرف")]
        [MaxLength(50)]
        public string? OwnerLastName { get; set; }

        [Display(Name = "کدملی متصرف")]
        [MaxLength(50)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدملی باید 10 رقم باشد")]
        public string? OwnerNationalCode { get; set; }

        [Display(Name = "شماره همراه متصرف")]
        [MaxLength(15)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه باید با 09 شروع شود و 11 رقم باشد")]
        public string? OwnerMobile { get; set; }

        [Display(Name = "نام پدر متصرف")]
        [MaxLength(50)]
        public string? OwnerFatherName { get; set; }

        [Display(Name = "تاریخ تولد متصرف")]
        public DateTime? OwnerBirthday { get; set; }

        [Display(Name = "واحد سهم مالکیت")]
        [MaxLength(50)]
        public string? OwnershipUnit { get; set; }

        [Display(Name = "تعداد سهم مالکیت")]
        [Range(0, double.MaxValue, ErrorMessage = "تعداد سهم باید عدد مثبت باشد")]
        public double? OwnershipQuantity { get; set; }

        [Display(Name = "ادله و امارات مالکیت متصرف")]
        [MaxLength(50)]
        public string? OwnershipProof { get; set; }

        // ==========================================
        // اطلاعات بهره‌بردار
        // ==========================================

        [Display(Name = "نام بهره بردار")]
        [MaxLength(50)]
        public string? OperatorName { get; set; }

        [Display(Name = "نام خانوادگی بهره بردار")]
        [MaxLength(50)]
        public string? OperatorLastName { get; set; }

        [Display(Name = "کدملی بهره بردار")]
        [MaxLength(15)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدملی باید 10 رقم باشد")]
        public string? OperatorNationalCode { get; set; }

        [Display(Name = "شماره همراه بهره بردار")]
        [MaxLength(15)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه باید با 09 شروع شود و 11 رقم باشد")]
        public string? OperatorMobile { get; set; }

        [Display(Name = "نام پدر بهره بردار")]
        [MaxLength(50)]
        public string? OperatorFatherName { get; set; }

        [Display(Name = "تاریخ تولد بهره بردار")]
        public DateTime? OperatorBirthday { get; set; }

        [Display(Name = "رابطه حقوقی بهره بردار با مالک")]
        [MaxLength(50)]
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