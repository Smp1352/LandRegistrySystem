// DTOs/Person/PersonViewDto.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.DTOs.Person
{
    public class PersonViewDto
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "کدملی")]
        public string? NationalCode { get; set; }

        [Display(Name = "شماره همراه")]
        public string? Mobile { get; set; }

        [Display(Name = "شماره تلفن ثابت")]
        public string? Phone { get; set; }

        [Display(Name = "نام پدر")]
        public string? FatherName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string? BirthDatePersian { get; set; }

        [Display(Name = "آدرس")]
        public string? Address { get; set; }

        [Display(Name = "ایمیل")]
        public string? Email { get; set; }

        [Display(Name = "کد پستی")]
        public string? PostalCode { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime? UpdatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}