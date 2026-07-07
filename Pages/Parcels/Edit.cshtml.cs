// Pages/Parcels/Edit.cshtml.cs
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Services;
using LandRegistrySystem.Helpers;
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

            // Map ViewDto به UpdateDto با تمام فیلدها
            Parcel = new ParcelUpdateDto
            {
                Id = parcel.Id,
                X = parcel.X,
                Y = parcel.Y,
                Zone = parcel.Zone,
                ParcelCode = parcel.ParcelCode,
                PostalCode = parcel.PostalCode,
                Area = parcel.Area,
                UniqueParcelCode = parcel.UniqueParcelCode,
                Province = parcel.Province,
                Shahrestan = parcel.Shahrestan,
                AbadiName = parcel.AbadiName,
                AbadiCode = parcel.AbadiCode,
                NahiyeSabti = parcel.NahiyeSabti,
                PlakName = parcel.PlakName,
                PlakAsli = parcel.PlakAsli,
                PlakFarei = parcel.PlakFarei,
                BakhshSabti = parcel.BakhshSabti,
                CurrentOperationLandUse = parcel.CurrentOperationLandUse,
                CropsType = parcel.CropsType,
                OwnerType = parcel.OwnerType,
                ShorakaTedad = parcel.ShorakaTedad,
                OwnerName = parcel.OwnerName,
                OwnerLastName = parcel.OwnerLastName,
                OwnerNationalCode = parcel.OwnerNationalCode,
                OwnerMobile = parcel.OwnerMobile,
                OwnerFatherName = parcel.OwnerFatherName,
                OwnerBirthdayPersian = parcel.OwnerBirthdayPersian,
                OwnershipUnit = parcel.OwnershipUnit,
                OwnershipQuantity = parcel.OwnershipQuantity,
                OwnershipProof = parcel.OwnershipProof,
                OperatorName = parcel.OperatorName,
                OperatorLastName = parcel.OperatorLastName,
                OperatorNationalCode = parcel.OperatorNationalCode,
                OperatorMobile = parcel.OperatorMobile,
                OperatorFatherName = parcel.OperatorFatherName,
                OperatorBirthdayPersian = parcel.OperatorBirthdayPersian,
                RelationOwnerOperator = parcel.RelationOwnerOperator,
                OwnershipConfirm = parcel.OwnershipConfirm,
                ChangeLandUse = parcel.ChangeLandUse,
                SanadMafroozi = parcel.SanadMafroozi,
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