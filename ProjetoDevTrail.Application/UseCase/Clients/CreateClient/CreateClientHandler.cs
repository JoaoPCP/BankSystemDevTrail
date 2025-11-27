using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.CreateClient
{
    public class CreateClientHandler(IClientRepository repo) : ICreateClientHandler
    {
        public async Task<ClientViewDTO> HandleAsync(CreateClientDTO dto)
        {
            Client newClient = Client.Create(dto.Name, dto.Email, dto.CPF, dto.BirthDate);
            var resultClient = await repo.AddAsync(newClient);
            var response = new ClientViewDTO(
                resultClient.Id,
                resultClient.Name,
                resultClient.Email,
                resultClient.CPF,
                resultClient.BirthDate
            );
            return response;
        }
    }
}
