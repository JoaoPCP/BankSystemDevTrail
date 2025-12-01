using System.ComponentModel.DataAnnotations;
using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class CreateAccountDTO
    {
        [Required(ErrorMessage = "O CPF do titular é obrigatório.")]
        public string OwnerCPF { get; }

        [Required(ErrorMessage = "O Tipo da conta é obrigatório.")]
        public AccountType AccountType { get; }

        public CreateAccountDTO(string ownerCPF, AccountType accountType)
        {
            OwnerCPF = ownerCPF;
            AccountType = accountType;
        }
    }
}
