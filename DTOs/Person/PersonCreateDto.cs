// DTOs/Person/PersonCreateDto.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.DTOs.Person
{
    public class PersonCreateDto
    {
        [Display(Name = "نام")]
        [MaxLength(50)]
        [Required(ErrorMessage = "نام الزامی است")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(50)]
        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        public string? LastName { get; set; }

        [Display(Name = "کدملی")]
        [MaxLength(10)]
        [Required(ErrorMessage = "کدملی الزامی است")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کدملی باید 10 رقم باشد")]
        public string? NationalCode { get; set; }

        [Display(Name = "شماره همراه")]
        [MaxLength(15)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه باید با 09 شروع شود و 11 رقم باشد")]
        public string? Mobile { get; set; }

        [Display(Name = "شماره تلفن ثابت")]
        [MaxLength(15)]
        public string? Phone { get; set; }

        [Display(Name = "نام پدر")]
        [MaxLength(50)]
        public string? FatherName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(200)]
        public string? Address { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string? Email { get; set; }

        [Display(Name = "کد پستی")]
        [MaxLength(10)]
        public string? PostalCode { get; set; }
    }

    public class PersonViewDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? FatherName { get; set; }
        public string? BirthDatePersian { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PostalCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    public class PersonSearchDto
    {
        public string? NationalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}