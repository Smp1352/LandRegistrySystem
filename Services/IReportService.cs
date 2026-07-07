// Services/IReportService.cs
using LandRegistrySystem.DTOs.Reports;

namespace LandRegistrySystem.Services
{
    public interface IReportService
    {
        Task<OwnerParcelsReportDto> GetOwnerParcelsReportAsync(string nationalCode);
    }
}