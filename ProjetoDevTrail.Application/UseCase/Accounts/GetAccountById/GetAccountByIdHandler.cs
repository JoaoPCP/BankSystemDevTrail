using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.GetAccountById
{
    public class GetAccountByIdHandler(IAccountRepository accRepo) : IGetAccountByIdHandler
    {
        public async Task<AccountViewDTO> HandleAsync(Guid id)
        {
            var account = await accRepo.GetByIdAsync(id);
            if (account == null)
                throw new NotFoundException("Conta não encontrada");
            return new AccountViewDTO(
                account.Id,
                account.Number,
                account.Owner!.Name,
                account.Owner.CPF,
                account.Type.ToString(),
                account.Status.ToString(),
                account.Balance
            );
        }
    }
}
