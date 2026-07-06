// Data/Repositories/Repository.cs
using LandRegistrySystem.Models.Entities;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LandRegistrySystem.Data.Repositories
{
    /// <summary>
    /// پیاده‌سازی عمومی Repository برای تمام Entity‌ها
    /// </summary>
    /// <typeparam name="T">نوع Entity</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // ===== عملیات خواندن =====

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null,
            bool trackChanges = false)
        {
            IQueryable<T> query = _dbSet;

            // اعمال فیلتر
            if (filter != null)
                query = query.Where(filter);

            // اعمال روابط (Include)
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            // عدم ردیابی برای بهبود عملکرد (برای عملیات خواندن)
            if (!trackChanges)
                query = query.AsNoTracking();

            // مرتب‌سازی
            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            bool trackChanges = false)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            if (!trackChanges)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            // اعمال فیلتر
            if (filter != null)
                query = query.Where(filter);

            // اعمال روابط (Include)
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            // محاسبه تعداد کل
            var totalCount = await query.CountAsync();

            // مرتب‌سازی و صفحه‌بندی
            if (orderBy != null)
                query = orderBy(query);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return (items, totalCount);
        }

        // ===== عملیات نوشتن =====

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void SoftDelete(T entity)
        {
            // فقط اگر Entity از BaseEntity ارث برده باشد
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.IsDeleted = true;
                baseEntity.UpdatedAt = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
            else
            {
                // اگر Entity از BaseEntity ارث نبرده، به جای آن حذف فیزیکی انجام می‌شود
                Delete(entity);
            }
        }

        public virtual void Restore(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.IsDeleted = false;
                baseEntity.UpdatedAt = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
        }

        // ===== عملیات کمکی =====

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _dbSet.AnyAsync();

            return await _dbSet.AnyAsync(filter);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _dbSet.CountAsync();

            return await _dbSet.CountAsync(filter);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}