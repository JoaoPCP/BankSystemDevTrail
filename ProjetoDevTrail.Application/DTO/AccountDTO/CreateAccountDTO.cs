using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class CreateAccountDTO
    {
        public string OwnerCPF { get; }
        public AccountType AccountType { get; }

        public CreateAccountDTO(string ownerCPF, AccountType accountType)
        {
            OwnerCPF = ownerCPF;
            AccountType = accountType;
        }
    }
}
