// Pages/Parcels/Index.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandRegistrySystem.Pages.Parcels
{
    public class IndexModel : PageModel
    {
        private readonly IParcelService _parcelService;

        public IndexModel(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        // ===== Properties =====
        public List<ParcelViewDto> Parcels { get; set; } = new();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public string? SearchTerm { get; set; }

        // ===== Pagination Helpers =====
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        // ===== Handler =====
        public async Task OnGetAsync(int page = 1, string searchTerm = "")
        {
            CurrentPage = page;
            SearchTerm = searchTerm;

            var result = await _parcelService.GetPagedParcelDtosAsync(
                pageNumber: CurrentPage,
                pageSize: PageSize,
                searchTerm: searchTerm
            );

            Parcels = result.Items.ToList();
            TotalCount = result.TotalCount;
            TotalPages = result.TotalPages;
        }
    }
}