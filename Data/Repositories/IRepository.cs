// Data/Repositories/IRepository.cs
using System.Linq.Expressions;

namespace LandRegistrySystem.Data.Repositories
{
    /// <summary>
    /// اینترفیس پایه برای تمام Repository‌ها
    /// </summary>
    /// <typeparam name="T">نوع Entity</typeparam>
    public interface IRepository<T> where T : class
    {
        // ===== عملیات خواندن =====

        /// <summary>
        /// دریافت تمام رکوردها (با قابلیت فیلتر، مرتب‌سازی و شامل کردن روابط)
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null,
            bool trackChanges = false
        );

        /// <summary>
        /// دریافت یک رکورد با شرط (با قابلیت شامل کردن روابط)
        /// </summary>
        Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            bool trackChanges = false
        );

        /// <summary>
        /// دریافت رکورد بر اساس شناسه
        /// </summary>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// دریافت یک صفحه از داده‌ها (برای صفحه‌بندی)
        /// </summary>
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
        );

        // ===== عملیات نوشتن =====

        /// <summary>
        /// افزودن رکورد جدید
        /// </summary>
        Task AddAsync(T entity);

        /// <summary>
        /// افزودن چند رکورد جدید
        /// </summary>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// بروزرسانی رکورد
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// بروزرسانی چند رکورد
        /// </summary>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// حذف فیزیکی رکورد
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// حذف فیزیکی چند رکورد
        /// </summary>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// حذف منطقی رکورد (Soft Delete - فقط اگر BaseEntity باشد)
        /// </summary>
        void SoftDelete(T entity);

        /// <summary>
        /// بازیابی رکورد حذف‌شده (Undo Soft Delete)
        /// </summary>
        void Restore(T entity);

        // ===== عملیات کمکی =====

        /// <summary>
        /// بررسی وجود رکورد بر اساس شرط
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null);

        /// <summary>
        /// شمارش تعداد رکوردها بر اساس شرط
        /// </summary>
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);

        /// <summary>
        /// ذخیره تغییرات
        /// </summary>
        Task SaveChangesAsync();
    }
}