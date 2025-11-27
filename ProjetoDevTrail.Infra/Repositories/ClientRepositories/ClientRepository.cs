using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Context;
using ProjetoDevTrail.Infra.Repositories.Interface;

namespace ProjetoDevTrail.Infra.Repositories.ClientRepositories
{
    public class ClientRepository(BankContext db) : BaseRepository<Client>(db), IClientRepository
    {
        public async Task<Client?> GetByCPFAsync(string cpf)
        {
            var client = await db.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.CPF == cpf);
            if (client == null)
                return null;

            return client;
        }
    }
}
