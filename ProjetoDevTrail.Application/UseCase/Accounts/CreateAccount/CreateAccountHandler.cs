using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Application.UseCase.Clients.GetClientByCPF;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount
{
    public class CreateAccountHandler(IAccountRepository AccRepo) : ICreateAccountHandler
    {
        public async Task<AccountViewDTO> HandleAsync(ClientViewDTO owner, CreateAccountDTO dto)
        {
            var account = Account.Create(owner.Id, dto.AccountType);
            await AccRepo.AddAsync(account);
            return new AccountViewDTO(
                account.Id,
                account.Numero,
                owner.Name,
                owner.CPF,
                account.Type.ToString(),
                account.Status.ToString(),
                account.Balance
            );
        }
    }
}
