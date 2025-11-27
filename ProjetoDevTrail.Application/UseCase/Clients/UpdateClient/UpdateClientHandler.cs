using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.UpdateClient
{
    public class UpdateClientHandler(IClientRepository repo) : IUpdateClientHandler
    {
        public async Task<ClientViewDTO> HandleAsync(Guid id, UpdateClientDTO dto)
        {
            var existingClient = await repo.GetByIdAsync(id);
            if (existingClient == null)
                throw new KeyNotFoundException("Client not found.");

            existingClient.Name = dto.Name;
            existingClient.Email = dto.Email;
            existingClient.UpdatedAt = DateTime.UtcNow;
            existingClient.BirthDate = dto.BirthDate;

            var updatedClient = await repo.UpdateAsync(existingClient);

            return new ClientViewDTO(
                updatedClient.Id,
                updatedClient.Name,
                updatedClient.Email,
                updatedClient.CPF,
                updatedClient.BirthDate
            );
        }
    }
}
