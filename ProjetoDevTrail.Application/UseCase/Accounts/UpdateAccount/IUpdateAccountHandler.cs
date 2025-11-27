using ProjetoDevTrail.Application.DTO.AccountDTO;

namespace ProjetoDevTrail.Application.UseCase.Accounts.UpdateAccount
{
    public interface IUpdateAccountHandler
    {
        public Task<AccountViewDTO> HandleAsync(Guid id, UpdateAccountDTO dto);
    }
}
