// Services/IPersonService.cs
using LandRegistrySystem.DTOs.Person;
using LandRegistrySystem.DTOs.Common;

namespace LandRegistrySystem.Services
{
    public interface IPersonService
    {
        Task<PersonViewDto?> GetPersonByIdAsync(int id);
        Task<PersonViewDto?> GetPersonByNationalCodeAsync(string nationalCode);
        Task<IEnumerable<PersonViewDto>> GetAllPersonsAsync();
        Task<PagedResultDto<PersonViewDto>> GetPagedPersonsAsync(PersonSearchDto searchDto);
        Task<int> CreatePersonAsync(PersonCreateDto createDto);
        Task<bool> UpdatePersonAsync(PersonCreateDto updateDto, int id);
        Task<bool> DeletePersonAsync(int id);
        Task<bool> PersonExistsAsync(string nationalCode);
    }
}