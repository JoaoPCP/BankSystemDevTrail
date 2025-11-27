using ProjetoDevTrail.Application.DTO.AccountDTO;

namespace ProjetoDevTrail.Application.UseCase.Accounts.GetAllAccounts
{
    public interface IGetAllAccountsHandler
    {
        public Task<List<AccountViewDTO>> HandleAsync();
    }
}
