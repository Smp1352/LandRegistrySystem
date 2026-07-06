// Data/Repositories/ParcelRepository.cs
using LandRegistrySystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LandRegistrySystem.Data.Repositories
{
    /// <summary>
    /// پیاده‌سازی اختصاصی برای عملیات مربوط به قطعات
    /// </summary>
    public class ParcelRepository : Repository<Parcel>, IParcelRepository
    {
        public ParcelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Parcel?> GetByParcelCodeAsync(string parcelCode)
        {
            return await _dbSet
                .FirstOrDefaultAsync(p => p.ParcelCode == parcelCode);
        }

        public async Task<Parcel?> GetByUniqueCodeAsync(double uniqueCode)
        {
            return await _dbSet
                .FirstOrDefaultAsync(p => p.UniqueParcelCode == uniqueCode);
        }

        public async Task<Parcel?> GetParcelWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Province)
                .Include(p => p.County)
                .Include(p => p.Village)
                .Include(p => p.ParcelOwners!)
                    .ThenInclude(po => po.Person)
                .Include(p => p.ParcelOperators!)
                    .ThenInclude(po => po.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Parcel?> GetParcelWithOwnersAsync(int id)
        {
            return await _dbSet
                .Include(p => p.ParcelOwners!)
                    .ThenInclude(po => po.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Parcel?> GetParcelWithOperatorsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.ParcelOperators!)
                    .ThenInclude(po => po.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Parcel>> SearchParcelsAsync(
            string? parcelCode = null,
            string? ownerNationalCode = null,
            string? province = null,
            string? shahrestan = null,
            string? abadiName = null,
            decimal? minArea = null,
            decimal? maxArea = null)
        {
            var query = _dbSet
                .Include(p => p.Province)
                .Include(p => p.County)
                .Include(p => p.Village)
                .AsQueryable();

            // اعمال فیلترها
            if (!string.IsNullOrWhiteSpace(parcelCode))
                query = query.Where(p => p.ParcelCode!.Contains(parcelCode));

            if (!string.IsNullOrWhiteSpace(ownerNationalCode))
            {
                query = query.Where(p =>
                    p.ParcelOwners != null &&
                    p.ParcelOwners.Any(po =>
                        po.Person != null &&
                        po.Person.NationalCode != null &&
                        po.Person.NationalCode.Contains(ownerNationalCode)));
            }

            if (!string.IsNullOrWhiteSpace(province))
                query = query.Where(p =>
                    p.Province != null &&
                    p.Province.Name != null &&
                    p.Province.Name.Contains(province));

            if (!string.IsNullOrWhiteSpace(shahrestan))
                query = query.Where(p =>
                    p.County != null &&
                    p.County.Name != null &&
                    p.County.Name.Contains(shahrestan));

            if (!string.IsNullOrWhiteSpace(abadiName))
                query = query.Where(p =>
                    p.Village != null &&
                    p.Village.Name != null &&
                    p.Village.Name.Contains(abadiName));

            if (minArea.HasValue)
                query = query.Where(p => p.Area >= minArea.Value);

            if (maxArea.HasValue)
                query = query.Where(p => p.Area <= maxArea.Value);

            return await query
                .OrderByDescending(p => p.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Parcel>> GetParcelsByProvinceAsync(int provinceId)
        {
            return await _dbSet
                .Where(p => p.ProvinceId == provinceId)
                .Include(p => p.County)
                .Include(p => p.Village)
                .OrderBy(p => p.ParcelCode)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Parcel>> GetParcelsByCountyAsync(int countyId)
        {
            return await _dbSet
                .Where(p => p.CountyId == countyId)
                .Include(p => p.Province)
                .Include(p => p.Village)
                .OrderBy(p => p.ParcelCode)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}