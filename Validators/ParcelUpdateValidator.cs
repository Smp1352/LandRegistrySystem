// Validators/ParcelUpdateValidator.cs
using FluentValidation;
using LandRegistrySystem.DTOs.Parcel;
using LandRegistrySystem.Helpers;

namespace LandRegistrySystem.Validators
{
    public class ParcelUpdateValidator : AbstractValidator<ParcelUpdateDto>
    {
        public ParcelUpdateValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه قطعه معتبر نیست");

            RuleFor(x => x.PersianName)
                .NotEmpty().WithMessage("نام فارسی عارضه الزامی است")
                .MaximumLength(100).WithMessage("نام فارسی حداکثر 100 کاراکتر است");

            RuleFor(x => x.EnglishName)
                .MaximumLength(100).WithMessage("نام انگلیسی حداکثر 100 کاراکتر است");

            RuleFor(x => x.Definition)
                .MaximumLength(500).WithMessage("تعریف عارضه حداکثر 500 کاراکتر است");

            RuleFor(x => x.ParcelCode)
                .MaximumLength(20).WithMessage("کد قطعه حداکثر 20 کاراکتر است");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("مساحت باید عدد مثبت باشد")
                .When(x => x.Area.HasValue);

            RuleFor(x => x.Description)
                .MaximumLength(254).WithMessage("توضیحات حداکثر 254 کاراکتر است");
        }
    }
}