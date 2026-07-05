// Entities/Base/BaseEntity.cs
using System.ComponentModel.DataAnnotations;

namespace LandRegistrySystem.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        // اضافه کردن فیلدهای جدید
        public string? CreatedBy { get; set; } // کاربر ایجاد کننده
        public string? UpdatedBy { get; set; } // کاربر ویرایش کننده
        public byte[]? RowVersion { get; set; } // برای Concurrency Control
    }
}