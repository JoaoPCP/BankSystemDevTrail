using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.Commons;

namespace ProjetoDevTrail.Infra.Repositories.TransactionRepositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public Task<List<Transaction>> GetByAccountIdAsync(Guid accountID);
    }
}
