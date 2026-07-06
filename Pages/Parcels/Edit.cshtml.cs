// Pages/Parcels/Edit.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class EditModel : PageModel
    {
        private readonly IParcelService _parcelService;

        public EditModel(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [BindProperty]
        public ParcelUpdateDto Parcel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var parcel = await _parcelService.GetParcelViewDtoByIdAsync(id);
            if (parcel == null)
                return NotFound();

            // Map ViewDto به UpdateDto
            Parcel = new ParcelUpdateDto
            {
                Id = parcel.Id,
                PersianName = parcel.PersianName,
                EnglishName = parcel.EnglishName,
                Definition = parcel.Definition,
                ParcelCode = parcel.ParcelCode,
                Area = parcel.Area,
                Description = parcel.Description
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _parcelService.UpdateParcelAsync(Parcel);
            if (!result)
            {
                ModelState.AddModelError("", "قطعه مورد نظر یافت نشد.");
                return Page();
            }

            TempData["Success"] = "قطعه با موفقیت ویرایش شد.";
            return RedirectToPage("./Details", new { id = Parcel.Id });
        }
    }
}