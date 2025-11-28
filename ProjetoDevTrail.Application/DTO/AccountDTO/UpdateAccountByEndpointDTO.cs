using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class UpdateAccountByEndpointDTO
    {
        public AccountStatus Status { get; }

        public UpdateAccountByEndpointDTO(AccountStatus status)
        {
            Status = status;
        }
    }
}
