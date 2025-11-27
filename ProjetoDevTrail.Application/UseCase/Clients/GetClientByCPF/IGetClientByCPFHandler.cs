using ProjetoDevTrail.Domain.Entities;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetClientByCPF
{
    public interface IGetClientByCPFHandler
    {
        public Task<Client?> HandleAsync(string cpf);
    }
}
