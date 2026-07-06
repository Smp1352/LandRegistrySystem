// DTOs/Parcel/ParcelUpdateDto.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.DTOs.Parcel
{
    /// <summary>
    /// DTO برای بروزرسانی قطعه
    /// </summary>
    public class ParcelUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام فارسی الزامی است")]
        [MaxLength(100)]
        public string PersianName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? EnglishName { get; set; }

        [MaxLength(500)]
        public string? Definition { get; set; }

        [MaxLength(20)]
        public string? ParcelCode { get; set; }

        public decimal? Area { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountyId { get; set; }
        public int? VillageId { get; set; }

        [MaxLength(254)]
        public string? Description { get; set; }
    }
}