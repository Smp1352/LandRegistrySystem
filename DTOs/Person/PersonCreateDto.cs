// DTOs/Person/PersonCreateDto.cs
using LandRegistrySystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.DTOs.Person
{
    public class PersonCreateDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام الزامی است")]
        [MaxLength(50, ErrorMessage = "نام حداکثر 50 کاراکتر است")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        [MaxLength(50, ErrorMessage = "نام خانوادگی حداکثر 50 کاراکتر است")]
        public string? LastName { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "کدملی الزامی است")]
        [MaxLength(10, ErrorMessage = "کدملی باید 10 رقم باشد")]
        [MinLength(10, ErrorMessage = "کدملی باید 10 رقم باشد")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدملی باید 10 رقم باشد")]
        public string? NationalCode { get; set; }

        [Display(Name = "شماره همراه")]
        [MaxLength(15, ErrorMessage = "شماره همراه حداکثر 15 کاراکتر است")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه باید با 09 شروع شود و 11 رقم باشد")]
        public string? Mobile { get; set; }

        [Display(Name = "شماره تلفن ثابت")]
        [MaxLength(15, ErrorMessage = "شماره تلفن حداکثر 15 کاراکتر است")]
        [RegularExpression(@"^0\d{2,3}\d{7,8}$", ErrorMessage = "شماره تلفن معتبر نیست")]
        public string? Phone { get; set; }

        [Display(Name = "نام پدر")]
        [MaxLength(50, ErrorMessage = "نام پدر حداکثر 50 کاراکتر است")]
        public string? FatherName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "آدرس حداکثر 500 کاراکتر است")]
        public string? Address { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(50, ErrorMessage = "ایمیل حداکثر 50 کاراکتر است")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string? Email { get; set; }

        [Display(Name = "کد پستی")]
        [MaxLength(10, ErrorMessage = "کد پستی حداکثر 10 کاراکتر است")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد پستی باید 10 رقم باشد")]
        public string? PostalCode { get; set; }
        public OwnerType? OwnerType { get; set; }
        public OwnershipUnit? OwnershipUnit { get; set; }
    }
}