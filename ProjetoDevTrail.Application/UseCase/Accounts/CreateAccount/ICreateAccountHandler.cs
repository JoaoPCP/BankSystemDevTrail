using ProjetoDevTrail.Application.DTO.AccountDTO;

namespace ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount
{
    public interface ICreateAccountHandler
    {
        public Task<AccountViewDTO> HandleAsync(CreateAccountDTO dto);
    }
}
