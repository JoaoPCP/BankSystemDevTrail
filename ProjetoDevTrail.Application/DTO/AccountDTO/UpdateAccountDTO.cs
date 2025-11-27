using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class UpdateAccountDTO
    {
        public AccountStatus Status { get; }

        public UpdateAccountDTO(AccountStatus status)
        {
            Status = status;
        }
    }
}
