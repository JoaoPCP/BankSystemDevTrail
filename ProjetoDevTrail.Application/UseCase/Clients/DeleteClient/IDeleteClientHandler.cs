namespace ProjetoDevTrail.Application.UseCase.Clients.DeleteClient
{
    public interface IDeleteClientHandler
    {
        public Task HandleAsync(Guid id);
    }
}
