// DTOs/Parcel/ParcelSearchDto.cs

namespace LandRegistrySystem.DTOs.Parcel
{
    /// <summary>
    /// DTO برای جستجوی قطعات
    /// </summary>
    public class ParcelSearchDto
    {
        public string? ParcelCode { get; set; }
        public string? OwnerNationalCode { get; set; }
        public string? ProvinceName { get; set; }
        public string? CountyName { get; set; }
        public string? VillageName { get; set; }
        public decimal? MinArea { get; set; }
        public decimal? MaxArea { get; set; }
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
}