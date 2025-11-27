using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Commons;

namespace ProjetoDevTrail.Infra.Repositories.Interface
{
    public abstract class BaseRepository<T>(DbContext db)
        where T : BaseEntity
    {
        private readonly DbContext db = db;

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await db.Set<T>().AsNoTracking().FirstAsync(e => e.Id == id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await db.Set<T>().Where(e => e.Id == id).ExecuteDeleteAsync();
        }
    }
}
