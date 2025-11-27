using ProjetoDevTrail.Application.DTO.ClientDTO;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetClientById
{
    public interface IGetClientByIdHandler
    {
        public Task<ClientViewDTO> HandleAsync(Guid id);
    }
}
