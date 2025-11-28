using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class UpdateAccountDTO
    {
        public AccountStatus? Status { get; }
        public Decimal? ValueToDeposit { get; }
        public Decimal? ValueToWithdraw { get; }

        public UpdateAccountDTO(
            AccountStatus? status = null,
            Decimal? valueToDeposit = null,
            Decimal? valueToWithdraw = null
        )
        {
            Status = status;
            ValueToDeposit = valueToDeposit;
            ValueToWithdraw = valueToWithdraw;
        }
    }
}
