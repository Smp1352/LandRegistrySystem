// Services/IPersonService.cs
using LandRegistrySystem.DTOs.Common;
using LandRegistrySystem.DTOs.Person;

namespace LandRegistrySystem.Services
{
    public interface IPersonService
    {
        // ===== دریافت =====
        Task<PersonViewDto?> GetPersonByIdAsync(int id);
        Task<PersonViewDto?> GetPersonByNationalCodeAsync(string nationalCode);
        Task<IEnumerable<PersonViewDto>> GetAllPersonsAsync();
        Task<PagedResultDto<PersonViewDto>> GetPagedPersonsAsync(PersonSearchDto searchDto);

        // ===== عملیات CRUD =====
        Task<int> CreatePersonAsync(PersonCreateDto createDto);
        Task<bool> UpdatePersonAsync(PersonCreateDto updateDto, int id);
        Task<bool> DeletePersonAsync(int id);
        Task<bool> HardDeletePersonAsync(int id);

        // ===== بررسی و جستجو =====
        Task<bool> PersonExistsAsync(string nationalCode);
        Task<IEnumerable<PersonViewDto>> SearchPersonsAsync(
            string? nationalCode = null,
            string? firstName = null,
            string? lastName = null,
            string? mobile = null);

        // ===== آمار =====
        Task<PersonStatisticsDto> GetPersonStatisticsAsync();
    }
}