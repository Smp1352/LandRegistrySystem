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

            // ==========================================
            // اطلاعات توصیفی TDB
            // ==========================================

            RuleFor(x => x.ParcelCode)
                .MaximumLength(20).WithMessage("کد قطعه حداکثر 20 کاراکتر است");

            RuleFor(x => x.PostalCode)
                .MaximumLength(20).WithMessage("کدپستی حداکثر 20 کاراکتر است")
                .Matches(@"^\d{10}$")
                .When(x => !string.IsNullOrEmpty(x.PostalCode))
                .WithMessage("کدپستی باید 10 رقم باشد");

            RuleFor(x => x.Area)
                .GreaterThan(0)
                .When(x => x.Area.HasValue)
                .WithMessage("مساحت باید عدد مثبت باشد");

            RuleFor(x => x.Province)
                .MaximumLength(50).WithMessage("استان حداکثر 50 کاراکتر است");

            RuleFor(x => x.Shahrestan)
                .MaximumLength(50).WithMessage("شهرستان حداکثر 50 کاراکتر است");

            RuleFor(x => x.AbadiName)
                .MaximumLength(50).WithMessage("نام آبادی حداکثر 50 کاراکتر است");

            RuleFor(x => x.AbadiCode)
                .Must(value => !value.HasValue || (value >= 1 && value <= 9999999999))
                .WithMessage("کد آبادی باید عدد معتبر باشد");

            // ==========================================
            // اطلاعات ثبتی
            // ==========================================

            RuleFor(x => x.NahiyeSabti)
                .MaximumLength(50).WithMessage("ناحیه ثبتی حداکثر 50 کاراکتر است");

            RuleFor(x => x.PlakName)
                .MaximumLength(50).WithMessage("نام پلاک ثبتی حداکثر 50 کاراکتر است");

            RuleFor(x => x.PlakAsli)
                .Must(value => !value.HasValue || (value >= 1 && value <= 99999))
                .WithMessage("شماره پلاک اصلی باید عدد معتبر باشد");

            RuleFor(x => x.PlakFarei)
                .Must(value => !value.HasValue || (value >= 1 && value <= 9999999999))
                .WithMessage("شماره پلاک فرعی باید عدد معتبر باشد");

            RuleFor(x => x.BakhshSabti)
                .Must(value => !value.HasValue || (value >= 1 && value <= 99999))
                .WithMessage("بخش ثبتی باید عدد معتبر باشد");

            RuleFor(x => x.CurrentOperationLandUse)
                .MaximumLength(50).WithMessage("بهره برداری فعلی حداکثر 50 کاراکتر است")
                .Must(x => string.IsNullOrEmpty(x) || new[]
                {
                    "زراعت آبی", "زراعت دیم", "باغ آبی", "باغ دیم",
                    "نهالستان / قلمستان", "پرورش طویل", "آبی‌پوری",
                    "صنایع تبدیلی و تکمیلی", "نوع محصول محصوالت"
                }.Contains(x))
                .WithMessage("نوع بهره برداری انتخاب شده معتبر نیست");

            RuleFor(x => x.CropsType)
                .MaximumLength(50).WithMessage("نوع محصول حداکثر 50 کاراکتر است");

            // ==========================================
            // اطلاعات مالک
            // ==========================================

            RuleFor(x => x.OwnerType)
                .IsInEnum()
                .WithMessage("نوع متصرف باید حقیقی یا حقوقی باشد");

            RuleFor(x => x.ShorakaTedad)
                .MaximumLength(10).WithMessage("تعداد شرکا حداکثر 10 کاراکتر است")
                .Matches(@"^\d+$")
                .When(x => !string.IsNullOrEmpty(x.ShorakaTedad))
                .WithMessage("تعداد شرکا باید عدد باشد");

            RuleFor(x => x.OwnerName)
                .MaximumLength(50).WithMessage("نام متصرف حداکثر 50 کاراکتر است");

            RuleFor(x => x.OwnerLastName)
                .MaximumLength(50).WithMessage("نام خانوادگی متصرف حداکثر 50 کاراکتر است");

            RuleFor(x => x.OwnerNationalCode)
                .Matches(@"^\d{10}$")
                .When(x => !string.IsNullOrEmpty(x.OwnerNationalCode))
                .WithMessage("کدملی باید 10 رقم باشد")
                .MaximumLength(50).WithMessage("کدملی حداکثر 50 کاراکتر است");

            RuleFor(x => x.OwnerMobile)
                .Matches(@"^09\d{9}$")
                .When(x => !string.IsNullOrEmpty(x.OwnerMobile))
                .WithMessage("شماره همراه باید با 09 شروع شود و 11 رقم باشد")
                .MaximumLength(15).WithMessage("شماره همراه حداکثر 15 کاراکتر است");

            RuleFor(x => x.OwnerFatherName)
                .MaximumLength(50).WithMessage("نام پدر متصرف حداکثر 50 کاراکتر است");

            RuleFor(x => x.OwnerBirthdayPersian)
                .Must(persianDate =>
                {
                    if (string.IsNullOrEmpty(persianDate))
                        return true;
                    return PersianDateHelper.IsValidPersianDate(persianDate);
                })
                .When(x => !string.IsNullOrEmpty(x.OwnerBirthdayPersian))
                .WithMessage("تاریخ تولد متصرف معتبر نیست (فرمت: yyyy/MM/dd)");

            RuleFor(x => x.OwnershipUnit)
                .IsInEnum()
                .WithMessage("نوع مالکیت باید عرصه، اعیان یا عرصه و اعیان باشد");

            RuleFor(x => x.OwnershipQuantity)
                .GreaterThan(0)
                .When(x => x.OwnershipQuantity.HasValue)
                .WithMessage("تعداد سهم مالکیت باید عدد مثبت باشد");

            RuleFor(x => x.OwnershipProof)
                .MaximumLength(500).WithMessage("ادله و امارات مالکیت حداکثر 500 کاراکتر است");

            // ==========================================
            // اطلاعات بهره‌بردار
            // ==========================================

            RuleFor(x => x.OperatorName)
                .MaximumLength(50).WithMessage("نام بهره بردار حداکثر 50 کاراکتر است");

            RuleFor(x => x.OperatorLastName)
                .MaximumLength(50).WithMessage("نام خانوادگی بهره بردار حداکثر 50 کاراکتر است");

            RuleFor(x => x.OperatorNationalCode)
                .Matches(@"^\d{10}$")
                .When(x => !string.IsNullOrEmpty(x.OperatorNationalCode))
                .WithMessage("کدملی بهره بردار باید 10 رقم باشد")
                .MaximumLength(15).WithMessage("کدملی بهره بردار حداکثر 15 کاراکتر است");

            RuleFor(x => x.OperatorMobile)
                .Matches(@"^09\d{9}$")
                .When(x => !string.IsNullOrEmpty(x.OperatorMobile))
                .WithMessage("شماره همراه بهره بردار باید با 09 شروع شود و 11 رقم باشد")
                .MaximumLength(15).WithMessage("شماره همراه بهره بردار حداکثر 15 کاراکتر است");

            RuleFor(x => x.OperatorFatherName)
                .MaximumLength(50).WithMessage("نام پدر بهره بردار حداکثر 50 کاراکتر است");

            RuleFor(x => x.OperatorBirthdayPersian)
                .Must(persianDate =>
                {
                    if (string.IsNullOrEmpty(persianDate))
                        return true;
                    return PersianDateHelper.IsValidPersianDate(persianDate);
                })
                .When(x => !string.IsNullOrEmpty(x.OperatorBirthdayPersian))
                .WithMessage("تاریخ تولد بهره بردار معتبر نیست (فرمت: yyyy/MM/dd)");

            RuleFor(x => x.RelationOwnerOperator)
                .MaximumLength(50).WithMessage("رابطه حقوقی حداکثر 50 کاراکتر است");

            RuleFor(x => x.OwnershipConfirm)
                .MaximumLength(50).WithMessage("روش احراز تصرفات حداکثر 50 کاراکتر است");

            // ==========================================
            // سایر اطلاعات
            // ==========================================

            RuleFor(x => x.ChangeLandUse)
                .MaximumLength(10).WithMessage("کاربری های غیرکشاورزی حداکثر 10 کاراکتر است");

            RuleFor(x => x.SanadMafroozi)
                .Must(x => string.IsNullOrEmpty(x) || new[] { "بله", "خیر" }.Contains(x))
                .WithMessage("سند مفروزی باید بله یا خیر باشد");

            RuleFor(x => x.Description)
                .MaximumLength(254).WithMessage("توضیحات حداکثر 254 کاراکتر است");
        }
    }
}