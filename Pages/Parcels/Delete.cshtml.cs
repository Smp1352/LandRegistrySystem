// Pages/Parcels/Delete.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class DeleteModel : PageModel
    {
        private readonly IParcelService _parcelService;

        public DeleteModel(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        public ParcelViewDto? Parcel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Parcel = await _parcelService.GetParcelViewDtoByIdAsync(id);
            if (Parcel == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var result = await _parcelService.DeleteParcelAsync(id);
            if (!result)
                return NotFound();

            TempData["Success"] = "قطعه با موفقیت حذف شد.";
            return RedirectToPage("./Index");
        }
    }
}