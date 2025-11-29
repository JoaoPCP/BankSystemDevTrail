using ProjetoDevTrail.Application.DTO.AccountDTO;

namespace ProjetoDevTrail.Application.UseCase.Accounts.GetByClient
{
    public interface IGetAccountByClientHandler
    {
        Task<List<AccountInListViewDTO>> HandleAsync(Guid Id);
    }
}
