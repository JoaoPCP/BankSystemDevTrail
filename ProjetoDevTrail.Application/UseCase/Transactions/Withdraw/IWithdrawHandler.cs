using ProjetoDevTrail.Application.DTO.TransactionDTO;

namespace ProjetoDevTrail.Application.UseCase.Transactions.Withdraw
{
    public interface IWithdrawHandler
    {
        public Task<WithdrawViewDTO> HandleAsync(WithdrawInputDTO dto);
    }
}
