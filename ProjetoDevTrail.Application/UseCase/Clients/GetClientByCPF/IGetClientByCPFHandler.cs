using ProjetoDevTrail.Application.DTO.ClientDTO;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetClientByCPF
{
    public interface IGetClientByCPFHandler
    {
        public Task<ClientViewDTO?> HandleAsync(string cpf);
    }
}
