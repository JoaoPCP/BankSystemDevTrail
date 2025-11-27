using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount
{
    public class CreateAccountHandler(IAccountRepository AccRepo, IClientRepository cliRepo)
        : ICreateAccountHandler
    {
        public async Task<AccountViewDTO> HandleAsync(CreateAccountDTO dto)
        {
            var owner = await cliRepo.GetByCPFAsync(dto.OwnerCPF);
            if (owner == null)
                throw new KeyNotFoundException("Não foi encontrado Cliente para o CPF fornecido");
            var account = Account.Create(owner.Id, dto.AccountType);
            await AccRepo.AddAsync(account);
            return new AccountViewDTO(
                account.Id,
                owner.Name,
                owner.CPF,
                account.Type.ToString(),
                account.Balance
            );
        }
    }
}
