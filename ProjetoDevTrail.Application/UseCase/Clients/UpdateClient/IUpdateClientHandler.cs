using ProjetoDevTrail.Application.DTO.ClientDTO;

namespace ProjetoDevTrail.Application.UseCase.Clients.UpdateClient
{
    public interface IUpdateClientHandler
    {
        public Task<ClientViewDTO> HandleAsync(Guid id, UpdateClientDTO dto);
    }
}
