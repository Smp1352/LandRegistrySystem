// Pages/TestService.cshtml.cs
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages
{
    public class TestServiceModel : PageModel
    {
        private readonly IParcelService _parcelService;

        public TestServiceModel(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        public string? Message { get; set; }
        public int ParcelCount { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                // ✅ استفاده از متد کمکی برای شمارش
                ParcelCount = await _parcelService.GetParcelsCountAsync();
                Message = $"Service is working! Number of parcels: {ParcelCount}";
            }
            catch (Exception ex)
            {
                Message = $"Service error: {ex.Message}";
            }
        }
    }
}