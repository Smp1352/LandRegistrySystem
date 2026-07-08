using LandRegistrySystem.DTOs.Person;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private readonly IPersonService _personService;

        public CreateModel(IPersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public PersonCreateDto Person { get; set; } = new();

        // ==========================================
        // خاصیت‌های مورد نیاز برای جستجو
        // ==========================================
        public PersonViewDto? FoundPerson { get; set; }
        public bool IsPersonFound { get; set; }
        public string? SearchNationalCode { get; set; }

        // ==========================================
        // جستجوی شخص با کدملی (GET)
        // ==========================================
        public async Task<IActionResult> OnGetAsync(string? nationalCode)
        {
            if (!string.IsNullOrEmpty(nationalCode))
            {
                SearchNationalCode = nationalCode;
                FoundPerson = await _personService.GetPersonByNationalCodeAsync(nationalCode);
                IsPersonFound = FoundPerson != null;

                if (IsPersonFound)
                {
                    // پر کردن فرم با اطلاعات پیدا شده
                    Person.FirstName = FoundPerson.FirstName;
                    Person.LastName = FoundPerson.LastName;
                    Person.NationalCode = FoundPerson.NationalCode;
                    Person.Mobile = FoundPerson.Mobile;
                    Person.Phone = FoundPerson.Phone;
                    Person.FatherName = FoundPerson.FatherName;
                    Person.Address = FoundPerson.Address;
                    Person.Email = FoundPerson.Email;
                    Person.PostalCode = FoundPerson.PostalCode;
                }
                else
                {
                    TempData["Error"] = "شخصی با این کدملی یافت نشد";
                }
            }

            return Page();
        }

        // ==========================================
        // ثبت شخص جدید (POST)
        // ==========================================
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                // بررسی کدملی تکراری
                var exists = await _personService.PersonExistsAsync(Person.NationalCode!);
                if (exists)
                {
                    ModelState.AddModelError("Person.NationalCode", "کدملی تکراری است");
                    return Page();
                }

                var id = await _personService.CreatePersonAsync(Person);
                TempData["Success"] = "شخص با موفقیت ثبت شد.";

                // اگر از صفحه دیگری آمده بود، برگرد
                if (Request.Query.ContainsKey("returnUrl"))
                {
                    return Redirect(Request.Query["returnUrl"]);
                }

                return RedirectToPage("./Details", new { id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"خطا در ثبت شخص: {ex.Message}");
                return Page();
            }
        }

        // ==========================================
        // جستجوی کدملی با AJAX
        // ==========================================
        public async Task<IActionResult> OnGetSearchNationalCode(string nationalCode)
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
                message = "شخص پیدا شد"
            });
        }
    }
}