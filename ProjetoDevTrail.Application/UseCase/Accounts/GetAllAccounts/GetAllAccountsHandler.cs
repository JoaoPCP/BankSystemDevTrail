using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.GetAllAccounts
{
    public class GetAllAccountsHandler(IAccountRepository accRepo) : IGetAllAccountsHandler
    {
        public async Task<List<AccountViewDTO>> HandleAsync()
        {
            var result = await accRepo.GetAllAsync();
            return result
                .Select(account => new AccountViewDTO(
                    account.Id,
                    account.Number,
                    account.Owner!.Name,
                    account.Owner.CPF,
                    account.Type.ToString(),
                    account.Status.ToString(),
                    account.Balance
                ))
                .ToList();
        }
    }
}
