using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.DTO.ClientDTO;

namespace ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount
{
    public interface ICreateAccountHandler
    {
        public Task<AccountViewDTO> HandleAsync(ClientViewDTO owner, CreateAccountDTO dto);
    }
}
