// DTOs/Parcel/ParcelViewDto.cs

namespace LandRegistrySystem.DTOs.Parcel
{
    /// <summary>
    /// DTO برای نمایش اطلاعات قطعه
    /// </summary>
    public class ParcelViewDto
    {
        public int Id { get; set; }

        // ===== مشخصات عمومی =====
        public string PersianName { get; set; } = string.Empty;
        public string? EnglishName { get; set; }
        public string? Definition { get; set; }
        public string? FeatureClass { get; set; }
        public string? FeatureType { get; set; }
        public string? Dimension { get; set; }

        // ===== اطلاعات توصیفی =====
        public string? ParcelCode { get; set; }
        public long? X { get; set; }
        public long? Y { get; set; }
        public long? Zone { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Area { get; set; }
        public double? UniqueParcelCode { get; set; }

        // ===== اطلاعات مکانی =====
        public string? ProvinceName { get; set; }
        public string? CountyName { get; set; }
        public string? VillageName { get; set; }

        // ===== اطلاعات ثبتی =====
        public string? NahiyeSabti { get; set; }
        public string? PlakName { get; set; }
        public int? PlakAsli { get; set; }
        public int? PlakFarei { get; set; }
        public int? BakhshSabti { get; set; }

        // ===== اطلاعات مالک =====
        public string? OwnerName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerNationalCode { get; set; }
        public string? OwnerMobile { get; set; }

        // ===== اطلاعات بهره‌بردار =====
        public string? OperatorName { get; set; }
        public string? OperatorLastName { get; set; }
        public string? OperatorNationalCode { get; set; }
        public string? OperatorMobile { get; set; }

        // ===== سایر اطلاعات =====
        public string? Description { get; set; }

        // ===== اطلاعات سیستمی =====
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}