using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.UpdateAccount
{
    public class UpdateAccountHandler : IUpdateAccountHandler
    {
        private readonly IAccountRepository _accRepo;

        public UpdateAccountHandler(IAccountRepository accRepo)
        {
            _accRepo = accRepo;
        }

        public async Task<AccountViewDTO> HandleAsync(Guid id, UpdateAccountDTO dto)
        {
            var account = await _accRepo.GetByIdAsync(id);

            if (account == null)
                throw new NotFoundException("Conta não encontrada");
            account.Status = dto.Status;
            await _accRepo.UpdateAsync(account);
            return new AccountViewDTO(
                account.Id,
                account.Numero,
                account.Owner!.Name,
                account.Owner.CPF,
                account.Type.ToString(),
                account.Status.ToString(),
                account.Balance
            );
        }
    }
}
