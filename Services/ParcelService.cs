// Services/ParcelService.cs
using AutoMapper;
using LandRegistrySystem.Data;
using LandRegistrySystem.DTOs.Common;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LandRegistrySystem.Services
{
    public class ParcelService : IParcelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ParcelService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // ==========================================
        // دریافت قطعه بر اساس شناسه
        // ==========================================
        public async Task<ParcelViewDto?> GetParcelViewDtoByIdAsync(int id)
        {
            return await GetParcelByIdAsync(id);
        }

        public async Task<ParcelViewDto?> GetParcelByIdAsync(int id)
        {
            var parcel = await _context.Parcels
                .AsNoTracking()
                .Include(p => p.Province)
                .Include(p => p.County)
                .Include(p => p.Village)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            return parcel == null ? null : _mapper.Map<ParcelViewDto>(parcel);
        }

        // ==========================================
        // دریافت همه قطعات
        // ==========================================
        public async Task<IEnumerable<ParcelViewDto>> GetAllParcelsAsync()
        {
            var parcels = await _context.Parcels
                .AsNoTracking()
                .Include(p => p.Province)
                .Include(p => p.County)
                .Include(p => p.Village)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ParcelViewDto>>(parcels);
        }

        // ==========================================
        // دریافت صفحه‌بندی شده قطعات
        // ==========================================
        public async Task<PagedResultDto<ParcelViewDto>> GetPagedParcelsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm = null)
        {
            var query = _context.Parcels
                .AsNoTracking()
                .Include(p => p.Province)
                .Include(p => p.County)
                .Include(p => p.Village)
                .Where(p => !p.IsDeleted);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p =>
                    (p.ParcelCode != null && p.ParcelCode.Contains(searchTerm)) ||
                    (p.Province != null && p.Province.Name != null && p.Province.Name.Contains(searchTerm)) ||
                    (p.County != null && p.County.Name != null && p.County.Name.Contains(searchTerm)));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResultDto<ParcelViewDto>
            {
                Items = _mapper.Map<IEnumerable<ParcelViewDto>>(items),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        // ==========================================
        // ایجاد قطعه جدید
        // ==========================================
        public async Task<int> CreateParcelAsync(ParcelCreateDto createDto)
        {
            // بررسی کد قطعه تکراری
            if (!string.IsNullOrEmpty(createDto.ParcelCode))
            {
                var exists = await _context.Parcels
                    .AnyAsync(p => p.ParcelCode == createDto.ParcelCode && !p.IsDeleted);
                if (exists)
                    throw new Exception("کد قطعه تکراری است");
            }

            var parcel = _mapper.Map<Parcel>(createDto);
            parcel.CreatedAt = DateTime.UtcNow;

            await _context.Parcels.AddAsync(parcel);
            await _context.SaveChangesAsync();

            return parcel.Id;
        }

        // ==========================================
        // بروزرسانی قطعه
        // ==========================================
        public async Task<bool> UpdateParcelAsync(ParcelUpdateDto updateDto)
        {
            var parcel = await _context.Parcels.FindAsync(updateDto.Id);
            if (parcel == null)
                return false;

            _mapper.Map(updateDto, parcel);
            parcel.UpdatedAt = DateTime.UtcNow;

            _context.Parcels.Update(parcel);
            await _context.SaveChangesAsync();

            return true;
        }

        // ==========================================
        // حذف قطعه (Soft Delete)
        // ==========================================
        public async Task<bool> DeleteParcelAsync(int id)
        {
            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
                return false;

            parcel.IsDeleted = true;
            parcel.UpdatedAt = DateTime.UtcNow;

            _context.Parcels.Update(parcel);
            await _context.SaveChangesAsync();

            return true;
        }

        // ==========================================
        // حذف فیزیکی قطعه
        // ==========================================
        public async Task<bool> HardDeleteParcelAsync(int id)
        {
            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
                return false;

            _context.Parcels.Remove(parcel);
            await _context.SaveChangesAsync();

            return true;
        }

        // ==========================================
        // بررسی وجود قطعه
        // ==========================================
        public async Task<bool> ParcelExistsAsync(int id)
        {
            return await _context.Parcels
                .AnyAsync(p => p.Id == id && !p.IsDeleted);
        }

        // ==========================================
        // بررسی وجود قطعه با کد
        // ==========================================
        public async Task<bool> ParcelExistsByCodeAsync(string parcelCode)
        {
            if (string.IsNullOrEmpty(parcelCode))
                return false;

            return await _context.Parcels
                .AnyAsync(p => p.ParcelCode == parcelCode && !p.IsDeleted);
        }

        // ==========================================
        // ✅ دریافت تعداد کل قطعات
        // ==========================================
        public async Task<int> GetParcelsCountAsync()
        {
            return await _context.Parcels
                .CountAsync(p => !p.IsDeleted);
        }

        // ==========================================
        // ✅ دریافت تعداد قطعات حذف شده
        // ==========================================
        public async Task<int> GetDeletedParcelsCountAsync()
        {
            return await _context.Parcels
                .CountAsync(p => p.IsDeleted);
        }

        // ==========================================
        // ✅ دریافت تعداد قطعات بر اساس استان
        // ==========================================
        public async Task<int> GetParcelsCountByProvinceAsync(int provinceId)
        {
            return await _context.Parcels
                .CountAsync(p => p.ProvinceId == provinceId && !p.IsDeleted);
        }

        // ==========================================
        // ✅ دریافت مجموع مساحت قطعات
        // ==========================================
        public async Task<decimal?> GetTotalAreaAsync()
        {
            return await _context.Parcels
                .Where(p => !p.IsDeleted)
                .SumAsync(p => p.Area);
        }
    }
}