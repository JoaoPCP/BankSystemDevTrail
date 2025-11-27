using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.DeleteAccount
{
    public class DeleteAccountHandler : IDeleteAccountHandler
    {
        private readonly IAccountRepository _accRepo;

        public DeleteAccountHandler(IAccountRepository accRepo)
        {
            _accRepo = accRepo;
        }

        public async Task HandleAsync(Guid accountId)
        {
            var account = await _accRepo.GetByIdAsync(accountId);
            if (account == null)
                throw new NotFoundException("Conta não encontrada");
            await _accRepo.DeleteAsync(accountId);
        }
    }
}
