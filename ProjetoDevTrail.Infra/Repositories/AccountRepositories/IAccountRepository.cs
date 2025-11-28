using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.Commons;

namespace ProjetoDevTrail.Infra.Repositories.AccountRepositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account?> GetByAccountNumberAsync(string accountNumber);
    }
}
