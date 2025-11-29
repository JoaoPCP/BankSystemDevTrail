using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetAllClients
{
    public class GetAllClientsHandler(IClientRepository repo) : IGetAllClientsHandler
    {
        private readonly IClientRepository _repo = repo;

        public async Task<IEnumerable<ClientViewDTO>> HandleAsync()
        {
            List<Client> result = await _repo.GetAllAsync();
            return result.Select(client => new ClientViewDTO(
                client.Id,
                client.Name,
                client.Email,
                client.CPF,
                client.BirthDate
            ));
        }
    }
}
