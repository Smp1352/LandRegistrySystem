// Models/Entities/Parcel.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandRegistrySystem.Models.Entities
{
    public class Parcel : BaseEntity
    {
        // ===== مشخصات عمومی =====

        [Display(Name = "نام عارضه (فارسی)")]
        [Required(ErrorMessage = "نام فارسی الزامی است")]
        [MaxLength(100)]
        public string PersianName { get; set; } = string.Empty;  // ← این را اضافه کنید

        [Display(Name = "نام عارضه (انگلیسی)")]
        [MaxLength(100)]
        public string? EnglishName { get; set; }

        [Display(Name = "تعریف عارضه")]
        [MaxLength(500)]
        public string? Definition { get; set; }

        [Display(Name = "کلاس عارضه")]
        [MaxLength(100)]
        public string? FeatureClass { get; set; }

        [Display(Name = "نوع عارضه")]
        [MaxLength(20)]
        public string? FeatureType { get; set; }

        [Display(Name = "بعد")]
        [MaxLength(10)]
        public string? Dimension { get; set; }

        // ===== اطلاعات توصیفی =====

        [Display(Name = "کد قطعه")]
        [MaxLength(20)]
        public string? ParcelCode { get; set; }

        [Display(Name = "مختصات X مرکز قطعه")]
        public long? X { get; set; }

        [Display(Name = "مختصات Y مرکز قطعه")]
        public long? Y { get; set; }

        [Display(Name = "زون مرکز قطعه")]
        public long? Zone { get; set; }

        [Display(Name = "کدپستی قطعه")]
        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [Display(Name = "مساحت(مترمربع)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Area { get; set; }

        [Display(Name = "کد شناسه یکتای قطعه")]
        public double? UniqueParcelCode { get; set; }

        // ===== اطلاعات مکانی =====

        [Display(Name = "استان")]
        [MaxLength(50)]
        public string? ProvinceName { get; set; }

        [Display(Name = "شهرستان")]
        [MaxLength(50)]
        public string? Shahrestan { get; set; }

        [Display(Name = "نام آبادی")]
        [MaxLength(50)]
        public string? AbadiName { get; set; }

        [Display(Name = "کد آبادی")]
        public int? AbadiCode { get; set; }

        // ===== روابط =====

        public int? ProvinceId { get; set; }
        public virtual Province? Province { get; set; }

        public int? CountyId { get; set; }
        public virtual County? County { get; set; }

        public int? VillageId { get; set; }
        public virtual Village? Village { get; set; }


        

        // ===== اطلاعات ثبتی =====

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

        // ===== اطلاعات کاربری =====

        [Display(Name = "بهره برداری فعلی")]
        [MaxLength(50)]
        public string? CurrentOperationLandUse { get; set; }

        [Display(Name = "نوع محصول")]
        [MaxLength(50)]
        public string? CropsType { get; set; }

        // ===== اطلاعات مالک =====

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
        public string? OwnerNationalCode { get; set; }

        [Display(Name = "شماره همراه متصرف")]
        [MaxLength(15)]
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OwnershipQuantity { get; set; }

        [Display(Name = "ادله و امارات مالکیت")]
        [MaxLength(50)]
        public string? OwnershipProof { get; set; }

        // ===== اطلاعات بهره‌بردار =====

        [Display(Name = "نام بهره بردار")]
        [MaxLength(50)]
        public string? OperatorName { get; set; }

        [Display(Name = "نام خانوادگی بهره بردار")]
        [MaxLength(50)]
        public string? OperatorLastName { get; set; }

        [Display(Name = "کدملی بهره بردار")]
        [MaxLength(15)]
        public string? OperatorNationalCode { get; set; }

        [Display(Name = "شماره همراه بهره بردار")]
        [MaxLength(15)]
        public string? OperatorMobile { get; set; }

        [Display(Name = "نام پدر بهره بردار")]
        [MaxLength(50)]
        public string? OperatorFatherName { get; set; }

        [Display(Name = "تاریخ تولد بهره بردار")]
        public DateTime? OperatorBirthday { get; set; }

        [Display(Name = "رابطه حقوقی با مالک")]
        [MaxLength(50)]
        public string? RelationOwnerOperator { get; set; }

        [Display(Name = "روش احراز تصرفات")]
        [MaxLength(50)]
        public string? OwnershipConfirm { get; set; }

        // ===== سایر اطلاعات =====

        [Display(Name = "کاربری های غیرکشاورزی")]
        [MaxLength(10)]
        public string? ChangeLandUse { get; set; }

        [Display(Name = "سند مفروزی دارد")]
        [MaxLength(5)]
        public string? SanadMafroozi { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(254)]
        public string? Description { get; set; }

        // ===== روابط Many-to-Many =====

        public virtual ICollection<ParcelOwner>? ParcelOwners { get; set; }
        public virtual ICollection<ParcelOperator>? ParcelOperators { get; set; }
    }
}