// Services/ReportService.cs
using LandRegistrySystem.Data;
using LandRegistrySystem.Data.Repositories;
using LandRegistrySystem.DTOs.Reports;
using LandRegistrySystem.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LandRegistrySystem.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OwnerParcelsReportDto> GetOwnerParcelsReportAsync(string nationalCode)
        {
            // جستجوی متصرف با کدملی
            var owner = await _context.Persons
                .FirstOrDefaultAsync(p => p.NationalCode == nationalCode);

            if (owner == null)
                throw new Exception("متصرفی با این کدملی یافت نشد");

            // دریافت لیست قطعات متعلق به این متصرف
            var parcels = await _context.Parcels
                .Where(p => p.ParcelOwners != null &&
                            p.ParcelOwners.Any(po => po.PersonId == owner.Id))
                .Include(p => p.Province)
                .Include(p => p.County)
                .Include(p => p.Village)
                .OrderBy(p => p.ParcelCode)
                .ToListAsync();

            // ساخت DTO گزارش
            var report = new OwnerParcelsReportDto
            {
                OwnerName = owner.FirstName,
                OwnerLastName = owner.LastName,
                OwnerNationalCode = owner.NationalCode,
                OwnerMobile = owner.Mobile,
                OwnerFatherName = owner.FatherName,
                OwnerBirthday = owner.BirthDate?.ToPersianDateString(),
                ReportDate = DateTime.Now,
                Parcels = parcels.Select(p => new ParcelReportItemDto
                {
                    Id = p.Id,
                    ParcelCode = p.ParcelCode,
                    PersianName = p.PersianName,
                    Province = p.Province?.Name,
                    Shahrestan = p.County?.Name,
                    AbadiName = p.Village?.Name,
                    Area = p.Area,
                    CurrentOperationLandUse = p.CurrentOperationLandUse,
                    CropsType = p.CropsType
                }).ToList()
            };

            return report;
        }
    }
}