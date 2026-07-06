// Services/IParcelService.cs
using LandRegistrySystem.DTOs.Common;
using LandRegistrySystem.DTOs.Parcel;

namespace LandRegistrySystem.Services
{
    public interface IParcelService
    {
        // ===== دریافت با DTO =====
        Task<ParcelViewDto?> GetParcelViewDtoByIdAsync(int id);
        Task<IEnumerable<ParcelViewDto>> GetAllParcelViewDtosAsync();  // ✅ نام صحیح
        Task<PagedResultDto<ParcelViewDto>> GetPagedParcelDtosAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm = null);

        // ===== عملیات CRUD با DTO =====
        Task<int> CreateParcelAsync(ParcelCreateDto createDto);
        Task<bool> UpdateParcelAsync(ParcelUpdateDto updateDto);
        Task<bool> DeleteParcelAsync(int id);

        // ===== جستجو =====
        Task<IEnumerable<ParcelViewDto>> SearchParcelDtosAsync(ParcelSearchDto searchDto);

        // ===== متدهای کمکی =====
        Task<int> GetParcelsCountAsync();  // ✅ متد جدید برای شمارش
    }
}