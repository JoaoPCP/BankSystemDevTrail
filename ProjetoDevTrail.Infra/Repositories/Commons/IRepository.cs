using ProjetoDevTrail.Domain.Commons;

namespace ProjetoDevTrail.Infra.Repositories.Commons
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync();

        public Task<T> AddAsync(T entity);

        public Task<T?> GetByIdAsync(Guid id);

        public Task<T> UpdateAsync(T entity);

        public Task DeleteAsync(Guid id);
    }
}
