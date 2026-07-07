// DTOs/Reports/OwnerParcelsReportDto.cs
using LandRegistrySystem.DTOs.Parcel;

namespace LandRegistrySystem.DTOs.Reports
{
    public class OwnerParcelsReportDto
    {
        // ===== اطلاعات متصرف =====
        public string? OwnerName { get; set; }
        public string? OwnerLastName { get; set; }
        public string? OwnerNationalCode { get; set; }
        public string? OwnerMobile { get; set; }
        public string? OwnerFatherName { get; set; }
        public string? OwnerBirthday { get; set; }

        // ===== لیست قطعات =====
        public List<ParcelReportItemDto> Parcels { get; set; } = new();

        // ===== اطلاعات گزارش =====
        public DateTime ReportDate { get; set; } = DateTime.Now;
        public int TotalParcels => Parcels.Count;
        public decimal? TotalArea => Parcels.Sum(p => p.Area);
    }

    public class ParcelReportItemDto
    {
        public int Id { get; set; }
        public string? ParcelCode { get; set; }
        public string? PersianName { get; set; }
        public string? Province { get; set; }
        public string? Shahrestan { get; set; }
        public string? AbadiName { get; set; }
        public decimal? Area { get; set; }
        public string? CurrentOperationLandUse { get; set; }
        public string? CropsType { get; set; }
    }
}