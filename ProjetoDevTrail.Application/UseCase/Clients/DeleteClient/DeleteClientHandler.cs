using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.DeleteClient
{
    public class DeleteClientHandler(IClientRepository repo) : IDeleteClientHandler
    {
        public async Task HandleAsync(Guid id)
        {
            await repo.DeleteAsync(id);
        }
    }
}
