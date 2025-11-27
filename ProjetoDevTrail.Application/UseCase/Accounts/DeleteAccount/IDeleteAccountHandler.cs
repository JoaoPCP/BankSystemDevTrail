namespace ProjetoDevTrail.Application.UseCase.Accounts.DeleteAccount
{
    public interface IDeleteAccountHandler
    {
        public Task HandleAsync(Guid accountId);
    }
}
