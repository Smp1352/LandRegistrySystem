// Data/Repositories/IParcelRepository.cs
using LandRegistrySystem.Models.Entities;

namespace LandRegistrySystem.Data.Repositories
{
    /// <summary>
    /// اینترفیس اختصاصی برای عملیات مربوط به قطعات
    /// </summary>
    public interface IParcelRepository : IRepository<Parcel>
    {
        /// <summary>
        /// دریافت قطعه بر اساس کد قطعه
        /// </summary>
        Task<Parcel?> GetByParcelCodeAsync(string parcelCode);

        /// <summary>
        /// دریافت قطعه بر اساس کد یکتا
        /// </summary>
        Task<Parcel?> GetByUniqueCodeAsync(double uniqueCode);

        /// <summary>
        /// دریافت قطعه به همراه تمام اطلاعات مرتبط (مالک، بهره‌بردار، استان، شهرستان، آبادی)
        /// </summary>
        Task<Parcel?> GetParcelWithDetailsAsync(int id);

        /// <summary>
        /// دریافت قطعه به همراه اطلاعات مالکین
        /// </summary>
        Task<Parcel?> GetParcelWithOwnersAsync(int id);

        /// <summary>
        /// دریافت قطعه به همراه اطلاعات بهره‌برداران
        /// </summary>
        Task<Parcel?> GetParcelWithOperatorsAsync(int id);

        /// <summary>
        /// جستجوی پیشرفته قطعات با فیلترهای مختلف
        /// </summary>
        Task<IEnumerable<Parcel>> SearchParcelsAsync(
            string? parcelCode = null,
            string? ownerNationalCode = null,
            string? province = null,
            string? shahrestan = null,
            string? abadiName = null,
            decimal? minArea = null,
            decimal? maxArea = null
        );

        /// <summary>
        /// دریافت قطعات یک استان
        /// </summary>
        Task<IEnumerable<Parcel>> GetParcelsByProvinceAsync(int provinceId);

        /// <summary>
        /// دریافت قطعات یک شهرستان
        /// </summary>
        Task<IEnumerable<Parcel>> GetParcelsByCountyAsync(int countyId);
    }
}