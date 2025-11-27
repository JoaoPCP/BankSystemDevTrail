using ProjetoDevTrail.Application.DTO.ClientDTO;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetAllClients
{
    public interface IGetAllClientsHandler
    {
        public Task<IEnumerable<ClientViewDTO>> HandleAsync();
    }
}
