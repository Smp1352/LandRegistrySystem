// Pages/Parcels/Create.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.DTOs.Person;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class CreateModel : PageModel
    {
        private readonly IParcelService _parcelService;
        private readonly IPersonService _personService;

        public CreateModel(IParcelService parcelService, IPersonService personService)
        {
            _parcelService = parcelService;
            _personService = personService;
        }

        [BindProperty]
        public ParcelCreateDto Parcel { get; set; } = new();

        // اطلاعات شخصی که با کدملی جستجو می‌شود
        public PersonViewDto? SelectedPerson { get; set; }

        // کدملی جستجو شده
        [BindProperty(SupportsGet = true)]
        public string? SearchNationalCode { get; set; }

        public async Task<IActionResult> OnGetAsync(string? nationalCode)
        {
            if (!string.IsNullOrEmpty(nationalCode))
            {
                SearchNationalCode = nationalCode;
                SelectedPerson = await _personService.GetPersonByNationalCodeAsync(nationalCode);

                if (SelectedPerson == null)
                {
                    TempData["Error"] = "شخصی با این کدملی یافت نشد. لطفاً ابتدا شخص را ثبت کنید.";
                }
                else
                {
                    // پر کردن اطلاعات شخص در فرم
                    Parcel.OwnerName = SelectedPerson.FirstName;
                    Parcel.OwnerLastName = SelectedPerson.LastName;
                    Parcel.OwnerNationalCode = SelectedPerson.NationalCode;
                    Parcel.OwnerMobile = SelectedPerson.Mobile;
                }
            }

            return Page();
        }

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