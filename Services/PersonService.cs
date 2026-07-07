// Services/PersonService.cs
using AutoMapper;
using LandRegistrySystem.Data;
using LandRegistrySystem.DTOs.Common;
using LandRegistrySystem.DTOs.Person;
using LandRegistrySystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LandRegistrySystem.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonViewDto?> GetPersonByIdAsync(int id)
        {
            var person = await _context.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return person == null ? null : _mapper.Map<PersonViewDto>(person);
        }

        public async Task<PersonViewDto?> GetPersonByNationalCodeAsync(string nationalCode)
        {
            var person = await _context.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.NationalCode == nationalCode);
            return person == null ? null : _mapper.Map<PersonViewDto>(person);
        }

        public async Task<IEnumerable<PersonViewDto>> GetAllPersonsAsync()
        {
            var persons = await _context.Persons
                .AsNoTracking()
                .OrderBy(p => p.FirstName)
                .ToListAsync();
            return _mapper.Map<IEnumerable<PersonViewDto>>(persons);
        }

        public async Task<PagedResultDto<PersonViewDto>> GetPagedPersonsAsync(PersonSearchDto searchDto)
        {
            var query = _context.Persons.AsNoTracking();

            if (!string.IsNullOrEmpty(searchDto.NationalCode))
                query = query.Where(p => p.NationalCode != null && p.NationalCode.Contains(searchDto.NationalCode));

            if (!string.IsNullOrEmpty(searchDto.FirstName))
                query = query.Where(p => p.FirstName != null && p.FirstName.Contains(searchDto.FirstName));

            if (!string.IsNullOrEmpty(searchDto.LastName))
                query = query.Where(p => p.LastName != null && p.LastName.Contains(searchDto.LastName));

            if (!string.IsNullOrEmpty(searchDto.Mobile))
                query = query.Where(p => p.Mobile != null && p.Mobile.Contains(searchDto.Mobile));

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderBy(p => p.FirstName)
                .Skip((searchDto.PageNumber - 1) * searchDto.PageSize)
                .Take(searchDto.PageSize)
                .ToListAsync();

            return new PagedResultDto<PersonViewDto>
            {
                Items = _mapper.Map<IEnumerable<PersonViewDto>>(items),
                TotalCount = totalCount,
                PageNumber = searchDto.PageNumber,
                PageSize = searchDto.PageSize
            };
        }

        public async Task<int> CreatePersonAsync(PersonCreateDto createDto)
        {
            // بررسی وجود کدملی تکراری
            var exists = await _context.Persons
                .AnyAsync(p => p.NationalCode == createDto.NationalCode);
            if (exists)
                throw new Exception("کدملی تکراری است");

            var person = _mapper.Map<Person>(createDto);
            person.CreatedAt = DateTime.UtcNow;

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return person.Id;
        }

        public async Task<bool> UpdatePersonAsync(PersonCreateDto updateDto, int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return false;

            // بررسی کدملی تکراری (به جز خود شخص)
            var exists = await _context.Persons
                .AnyAsync(p => p.NationalCode == updateDto.NationalCode && p.Id != id);
            if (exists)
                throw new Exception("کدملی تکراری است");

            _mapper.Map(updateDto, person);
            person.UpdatedAt = DateTime.UtcNow;

            _context.Persons.Update(person);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return false;

            // بررسی اینکه شخص در قطعات استفاده نشده باشد
            var isUsed = await _context.ParcelOwners
                .AnyAsync(po => po.PersonId == id);
            if (isUsed)
                throw new Exception("این شخص در قطعات استفاده شده است و قابل حذف نیست");

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PersonExistsAsync(string nationalCode)
        {
            return await _context.Persons
                .AnyAsync(p => p.NationalCode == nationalCode);
        }
    }
}