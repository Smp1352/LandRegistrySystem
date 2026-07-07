// DTOs/Parcel/ParcelViewDto.cs
using LandRegistrySystem.Models.Enums;

namespace LandRegistrySystem.DTOs.Parcel
{
    public class ParcelViewDto
    {
        public int Id { get; set; }

        // ==========================================
        // مشخصات عمومی
        // ==========================================

        public string? PersianName { get; set; }        // ✅ اضافه شد
        public string? EnglishName { get; set; }        // ✅ اضافه شد (در صورت نیاز)
        public string? Definition { get; set; }         // ✅ اضافه شد (در صورت نیاز)
        public string? FeatureClass { get; set; }       // ✅ اضافه شد (در صورت نیاز)
        public string? FeatureType { get; set; }        // ✅ اضافه شد (در صورت نیاز)
        public string? Dimension { get; set; }          // ✅ اضافه شد (در صورت نیاز)

        // ==========================================
        // اطلاعات توصیفی TDB
        // ==========================================

        public long? X { get; set; }
        public long? Y { get; set; }
        public long? Zone { get; set; }
        public string? ParcelCode { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Area { get; set; }
        public double? UniqueParcelCode { get; set; }

        // ==========================================
        // اطلاعات مکانی
        // ==========================================

        public string? Province { get; set; }
        public string? Shahrestan { get; set; }
        public string? AbadiName { get; set; }
        public int? AbadiCode { get; set; }

        // ==========================================
        // اطلاعات ثبتی
        // ==========================================

        public string? NahiyeSabti { get; set; }
        public string? PlakName { get; set; }
        public int? PlakAsli { get; set; }
        public int? PlakFarei { get; set; }
        public int? BakhshSabti { get; set; }

        // ==========================================
        // اطلاعات کاربری و بهره‌برداری
        // ==========================================

        public string? CurrentOperationLandUse { get; set; }
        public string? CropsType { get; set; }

        // ==========================================
        // اطلاعات مالک (متصرف)
        // ==========================================

        public OwnerType? OwnerType { get; set; }
        public string? ShorakaTedad { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerNationalCode { get; set; }
        public string? OwnerMobile { get; set; }
        public string? OwnerFatherName { get; set; }
        public string? OwnerBirthdayPersian { get; set; }
        public OwnershipUnit? OwnershipUnit { get; set; }
        public double? OwnershipQuantity { get; set; }
        public string? OwnershipProof { get; set; }

        // ==========================================
        // اطلاعات بهره‌بردار
        // ==========================================

        public string? OperatorName { get; set; }
        public string? OperatorLastName { get; set; }
        public string? OperatorNationalCode { get; set; }
        public string? OperatorMobile { get; set; }
        public string? OperatorFatherName { get; set; }
        public string? OperatorBirthdayPersian { get; set; }
        public string? RelationOwnerOperator { get; set; }
        public string? OwnershipConfirm { get; set; }

        // ==========================================
        // سایر اطلاعات
        // ==========================================

        public string? ChangeLandUse { get; set; }
        public string? SanadMafroozi { get; set; }
        public string? Description { get; set; }

        // ==========================================
        // اطلاعات سیستمی
        // ==========================================

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // ==========================================
        // نام‌های نمایشی برای روابط
        // ==========================================

        public string? ProvinceName { get; set; }
        public string? CountyName { get; set; }
        public string? VillageName { get; set; }
    }
}