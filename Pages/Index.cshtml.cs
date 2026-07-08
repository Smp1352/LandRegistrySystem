// Pages/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // در صورت نیاز، داده‌های اولیه را بارگذاری کنید
        }
    }
}