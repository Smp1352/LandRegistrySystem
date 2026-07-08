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

        // ==========================================
        // دریافت شخص بر اساس شناسه
        // ==========================================
        public async Task<PersonViewDto?> GetPersonByIdAsync(int id)
        {
            var person = await _context.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return person == null ? null : _mapper.Map<PersonViewDto>(person);
        }

        // ==========================================
        // دریافت شخص بر اساس کدملی
        // ==========================================
        public async Task<PersonViewDto?> GetPersonByNationalCodeAsync(string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                return null;

            var person = await _context.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.NationalCode == nationalCode);

            return person == null ? null : _mapper.Map<PersonViewDto>(person);
        }

        // ==========================================
        // دریافت همه اشخاص
        // ==========================================
        public async Task<IEnumerable<PersonViewDto>> GetAllPersonsAsync()
        {
            var persons = await _context.Persons
                .AsNoTracking()
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PersonViewDto>>(persons);
        }

        // ==========================================
        // دریافت صفحه‌بندی شده اشخاص
        // ==========================================
        public async Task<PagedResultDto<PersonViewDto>> GetPagedPersonsAsync(PersonSearchDto searchDto)
        {
            var query = _context.Persons.AsNoTracking();

            // اعمال فیلترها
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
                .ThenBy(p => p.LastName)
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

        // ==========================================
        // ایجاد شخص جدید
        // ==========================================
        public async Task<int> CreatePersonAsync(PersonCreateDto createDto)
        {
            try
            {
                // اعتبارسنجی کدملی
                if (string.IsNullOrEmpty(createDto.NationalCode))
                    throw new Exception("کدملی الزامی است");

                if (createDto.NationalCode.Length != 10 || !createDto.NationalCode.All(char.IsDigit))
                    throw new Exception("کدملی باید 10 رقم باشد");

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
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"خطا در ذخیره‌سازی دیتابیس: {innerException}");
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در ثبت شخص: {ex.Message}");
            }
        }

        // ==========================================
        // بروزرسانی شخص
        // ==========================================
        public async Task<bool> UpdatePersonAsync(PersonCreateDto updateDto, int id)
        {
            try
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
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"خطا در بروزرسانی دیتابیس: {innerException}");
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در بروزرسانی شخص: {ex.Message}");
            }
        }

        // ==========================================
        // حذف شخص (Soft Delete)
        // ==========================================
        public async Task<bool> DeletePersonAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return false;

            // بررسی اینکه شخص در قطعات استفاده نشده باشد
            var isUsedInParcelOwners = await _context.ParcelOwners
                .AnyAsync(po => po.PersonId == id);

            var isUsedInParcelOperators = await _context.ParcelOperators
                .AnyAsync(po => po.PersonId == id);

            if (isUsedInParcelOwners || isUsedInParcelOperators)
                throw new Exception("این شخص در قطعات استفاده شده است و قابل حذف نیست");

            // Soft Delete
            person.IsDeleted = true;
            person.UpdatedAt = DateTime.UtcNow;

            _context.Persons.Update(person);
            await _context.SaveChangesAsync();

            return true;
        }

        // ==========================================
        // حذف فیزیکی شخص (اختیاری)
        // ==========================================
        public async Task<bool> HardDeletePersonAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }

        // ==========================================
        // بررسی وجود شخص با کدملی
        // ==========================================
        public async Task<bool> PersonExistsAsync(string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                return false;

            return await _context.Persons
                .AnyAsync(p => p.NationalCode == nationalCode);
        }

        // ==========================================
        // جستجوی پیشرفته اشخاص
        // ==========================================
        public async Task<IEnumerable<PersonViewDto>> SearchPersonsAsync(
            string? nationalCode = null,
            string? firstName = null,
            string? lastName = null,
            string? mobile = null)
        {
            var query = _context.Persons.AsNoTracking();

            if (!string.IsNullOrEmpty(nationalCode))
                query = query.Where(p => p.NationalCode != null && p.NationalCode.Contains(nationalCode));

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(p => p.FirstName != null && p.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(p => p.LastName != null && p.LastName.Contains(lastName));

            if (!string.IsNullOrEmpty(mobile))
                query = query.Where(p => p.Mobile != null && p.Mobile.Contains(mobile));

            var persons = await query
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PersonViewDto>>(persons);
        }

        // ==========================================
        // دریافت آمار اشخاص
        // ==========================================
        public async Task<PersonStatisticsDto> GetPersonStatisticsAsync()
        {
            var total = await _context.Persons.CountAsync();

            var withMobile = await _context.Persons
                .CountAsync(p => p.Mobile != null);

            var withEmail = await _context.Persons
                .CountAsync(p => p.Email != null);

            return new PersonStatisticsDto
            {
                TotalPersons = total,
                PersonsWithMobile = withMobile,
                PersonsWithEmail = withEmail
            };
        }
    }
}