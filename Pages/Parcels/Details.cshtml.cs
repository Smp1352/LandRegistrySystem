// Pages/Parcels/Details.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class DetailsModel : PageModel
    {
        private readonly IParcelService _parcelService;

        public DetailsModel(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        public ParcelViewDto? Parcel { get; set; }

        public async Task OnGetAsync(int id)
        {
            // ✅ استفاده از نام صحیح متد
            Parcel = await _parcelService.GetParcelByIdAsync(id);
        }
    }
}