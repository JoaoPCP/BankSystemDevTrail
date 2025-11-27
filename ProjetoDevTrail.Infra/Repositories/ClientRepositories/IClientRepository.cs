using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.Commons;

namespace ProjetoDevTrail.Infra.Repositories.ClientRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        public Task<Client?> GetByCPFAsync(string cpf);
    }
}
