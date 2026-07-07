// Models/Entities/Person.cs

using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities
{
    public class Person : BaseEntity
    {
        [MaxLength(50)]
        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [MaxLength(10)]
        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "کدملی الزامی است")]
        public string? NationalCode { get; set; }

        [MaxLength(15)]
        [Display(Name = "شماره همراه")]
        public string? Mobile { get; set; }

        [MaxLength(15)]
        [Display(Name = "شماره تلفن ثابت")]
        public string? Phone { get; set; }

        [MaxLength(50)]
        [Display(Name = "نام پدر")]
        public string? FatherName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        [MaxLength(200)]
        [Display(Name = "آدرس")]
        public string? Address { get; set; }

        [MaxLength(50)]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string? Email { get; set; }

        [MaxLength(10)]
        [Display(Name = "کد پستی")]
        public string? PostalCode { get; set; }

        // روابط
        public virtual ICollection<ParcelOwner>? ParcelOwners { get; set; }
        public virtual ICollection<ParcelOperator>? ParcelOperators { get; set; }
    }
}