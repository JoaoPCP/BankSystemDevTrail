using ProjetoDevTrail.Application.DTO.ClientDTO;

namespace ProjetoDevTrail.Application.UseCase.Clients.CreateClient
{
    public interface ICreateClientHandler
    {
        public Task<ClientViewDTO> HandleAsync(CreateClientDTO dto);
    }
}
