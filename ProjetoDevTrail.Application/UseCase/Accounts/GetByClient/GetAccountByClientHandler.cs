using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.GetByClient
{
    public class GetAccountByClientHandler : IGetAccountByClientHandler
    {
        private readonly IAccountRepository _accRepo;

        public GetAccountByClientHandler(IAccountRepository accRepo)
        {
            _accRepo = accRepo;
        }

        public async Task<List<AccountInListViewDTO>> HandleAsync(Guid Id)
        {
            List<AccountInListViewDTO> accountList = (await _accRepo.GetByClientIdAsync(Id))
                .Select(acc => new AccountInListViewDTO(
                    id: acc.Id,
                    number: acc.Number,
                    accountType: acc.Type.ToString(),
                    accountStatus: acc.Status.ToString(),
                    balance: acc.Balance
                ))
                .ToList();
            return accountList;
        }
    }
}
