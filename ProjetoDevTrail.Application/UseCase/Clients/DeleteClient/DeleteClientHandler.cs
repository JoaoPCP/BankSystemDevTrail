using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.DeleteClient
{
    public class DeleteClientHandler(IClientRepository repo) : IDeleteClientHandler
    {
        private readonly IClientRepository _repo = repo;

        public async Task HandleAsync(Guid id)
        {
            var clienteExists = await _repo.GetByIdAsync(id);
            if (clienteExists == null)
                throw new NotFoundException("Cliente não encontrado");
            await _repo.DeleteAsync(id);
        }
    }
}
