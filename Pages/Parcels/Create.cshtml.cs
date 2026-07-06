// Pages/Parcels/Create.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class CreateModel : PageModel
    {
        private readonly IParcelService _parcelService;

        public CreateModel(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [BindProperty]
        public ParcelCreateDto Parcel { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var id = await _parcelService.CreateParcelAsync(Parcel);
                TempData["Success"] = "قطعه با موفقیت ثبت شد.";
                return RedirectToPage("./Details", new { id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"خطا در ثبت قطعه: {ex.Message}");
                return Page();
            }
        }
    }
}