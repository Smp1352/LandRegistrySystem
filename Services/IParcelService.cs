// Services/IParcelService.cs
using LandRegistrySystem.DTOs.Common;
using LandRegistrySystem.DTOs.Parcel;

public interface IParcelService
{
    // ===== دریافت =====
    Task<ParcelViewDto?> GetParcelByIdAsync(int id);
    Task<ParcelViewDto?> GetParcelViewDtoByIdAsync(int id); // ✅ اضافه کنید
    Task<IEnumerable<ParcelViewDto>> GetAllParcelsAsync();
    Task<PagedResultDto<ParcelViewDto>> GetPagedParcelsAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null);

    // ===== عملیات CRUD =====
    Task<int> CreateParcelAsync(ParcelCreateDto createDto);
    Task<bool> UpdateParcelAsync(ParcelUpdateDto updateDto);
    Task<bool> DeleteParcelAsync(int id);
    Task<bool> HardDeleteParcelAsync(int id);

    // ===== بررسی وجود =====
    Task<bool> ParcelExistsAsync(int id);
    Task<bool> ParcelExistsByCodeAsync(string parcelCode);

    // ===== آمار =====
    Task<int> GetParcelsCountAsync();
}