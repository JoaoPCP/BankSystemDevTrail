using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.CreateClient
{
    public class CreateClientHandler(IClientRepository repo) : ICreateClientHandler
    {
        private readonly IClientRepository _repo = repo;

        public async Task<ClientViewDTO> HandleAsync(CreateClientDTO dto)
        {
            var clientExists = await _repo.GetByCPFAsync(dto.CPF);
            if (clientExists != null)
                throw new ConflictException("Já existe um cliente com esse CPF");

            Client newClient = Client.Create(dto.Name, dto.Email, dto.CPF, dto.BirthDate);
            var resultClient = await _repo.AddAsync(newClient);
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
