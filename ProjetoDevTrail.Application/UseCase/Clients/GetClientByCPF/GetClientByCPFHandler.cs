using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetClientByCPF
{
    public class GetClientByCPFHandler(IClientRepository repo) : IGetClientByCPFHandler
    {
        public async Task<ClientViewDTO?> HandleAsync(string cpf)
        {
            var client = await repo.GetByCPFAsync(cpf);
            if (client == null)
                throw new NotFoundException("Cliente não encontrado para o CPF informado");
            return new ClientViewDTO(
                client.Id,
                client.Name,
                client.Email,
                client.CPF,
                client.BirthDate
            );
        }
    }
}
