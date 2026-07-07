// Pages/Persons/Create.cshtml.cs
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

        public IActionResult OnGet()
        {
            // مقداردهی اولیه (در صورت نیاز)
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // اعتبارسنجی سمت سرور
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var id = await _personService.CreatePersonAsync(Person);
                TempData["Success"] = "شخص با موفقیت ثبت شد.";
                return RedirectToPage("./Details", new { id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"خطا در ثبت شخص: {ex.Message}");
                return Page();
            }
        }
    }
}