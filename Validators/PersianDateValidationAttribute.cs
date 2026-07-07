// Validators/PersianDateValidationAttribute.cs
using System.ComponentModel.DataAnnotations;
using LandRegistrySystem.Helpers;

namespace LandRegistrySystem.Validators
{
    public class PersianDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.Success;

            var dateString = value.ToString()!;

            if (!PersianDateHelper.IsValidPersianDate(dateString))
            {
                return new ValidationResult(ErrorMessage ?? "تاریخ وارد شده معتبر نیست");
            }

            return ValidationResult.Success;
        }
    }
}