using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetClientByCPF
{
    public class GetClientByCPFHandler(IClientRepository repo) : IGetClientByCPFHandler
    {
        public async Task<Client?> HandleAsync(string cpf)
        {
            var client = await repo.GetByCPFAsync(cpf);
            if (client == null)
                throw new KeyNotFoundException("Cliente não encontrado para o CPF informado");
            return client;
        }
    }
}
