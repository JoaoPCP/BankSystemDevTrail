using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Context;
using ProjetoDevTrail.Infra.Repositories.Interface;

namespace ProjetoDevTrail.Infra.Repositories.ClientRepositories
{
    public class ClientRepository(BankContext db)
        : BaseRepository<Client>(db),
            IClientRepository { }
}
