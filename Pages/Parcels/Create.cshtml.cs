// Pages/Parcels/Create.cshtml.cs
using FluentValidation;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class CreateModel : PageModel
    {
        private readonly IParcelService _parcelService;
        private readonly IValidator<ParcelCreateDto> _validator;

        public CreateModel(IParcelService parcelService, IValidator<ParcelCreateDto> validator)
        {
            _parcelService = parcelService;
            _validator = validator;
        }

        [BindProperty]
        public ParcelCreateDto Parcel { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // ==========================================
            // اعتبارسنجی با FluentValidation
            // ==========================================
            var validationResult = await _validator.ValidateAsync(Parcel);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError($"Parcel.{error.PropertyName}", error.ErrorMessage);
                }
                return Page();
            }

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