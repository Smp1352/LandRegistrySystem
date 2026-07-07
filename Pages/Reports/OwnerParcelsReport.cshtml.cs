// Pages/Reports/OwnerParcelsReport.cshtml.cs
using LandRegistrySystem.DTOs.Reports;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Reports
{
    public class OwnerParcelsReportModel : PageModel
    {
        private readonly IReportService _reportService;

        public OwnerParcelsReportModel(IReportService reportService)
        {
            _reportService = reportService;
        }

        [BindProperty(SupportsGet = true)]
        public string? NationalCode { get; set; }

        public OwnerParcelsReportDto? Report { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(NationalCode))
            {
                ErrorMessage = "لطفاً کدملی را وارد کنید";
                return Page();
            }

            try
            {
                Report = await _reportService.GetOwnerParcelsReportAsync(NationalCode);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostPrintAsync(string nationalCode)
        {
            // این متد برای چاپ مستقیم استفاده می‌شود
            return RedirectToPage(new { nationalCode });
        }
    }
}