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
        private readonly IPersonService _personService;

        public CreateModel(IParcelService parcelService, IPersonService personService)
        {
            _parcelService = parcelService;
            _personService = personService;
        }

        [BindProperty]
        public ParcelCreateDto Parcel { get; set; } = new();

        // ==========================================
        // صفحه GET - بارگذاری فرم
        // ==========================================
        public IActionResult OnGet()
        {
            return Page();
        }

        // ==========================================
        // ثبت قطعه جدید (POST)
        // ==========================================
        public async Task<IActionResult> OnPostAsync()
        {
            // ✅ نمایش خطاهای ModelState در کنسول (برای دیباگ)
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            try
            {
                // ✅ ثبت قطعه
                var id = await _parcelService.CreateParcelAsync(Parcel);

                TempData["Success"] = "قطعه با موفقیت ثبت شد.";
                return RedirectToPage("./Details", new { id });
            }
            catch (Exception ex)
            {
                // ✅ نمایش خطای کامل در صفحه
                ModelState.AddModelError("", $"خطا در ثبت قطعه: {ex.Message}");

                // ✅ اگر خطای داخلی وجود دارد، آن را هم نمایش بده
                if (ex.InnerException != null)
                {
                    ModelState.AddModelError("", $"جزئیات خطا: {ex.InnerException.Message}");
                }

                return Page();
            }
        }

        // ==========================================
        // جستجوی شخص با کدملی (AJAX)
        // ==========================================
        public async Task<IActionResult> OnGetSearchPerson(string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                return new JsonResult(new { exists = false, message = "کدملی را وارد کنید" });

            var person = await _personService.GetPersonByNationalCodeAsync(nationalCode);
            if (person == null)
                return new JsonResult(new { exists = false, message = "شخصی با این کدملی یافت نشد" });

            return new JsonResult(new
            {
                exists = true,
                firstName = person.FirstName,
                lastName = person.LastName,
                mobile = person.Mobile,
                phone = person.Phone,
                fatherName = person.FatherName,
                address = person.Address,
                email = person.Email,
                postalCode = person.PostalCode,
                birthDatePersian = person.BirthDatePersian,
                message = "شخص پیدا شد"
            });
        }
    }
}