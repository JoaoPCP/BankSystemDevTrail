using ProjetoDevTrail.Application.DTO.TransactionDTO;

namespace ProjetoDevTrail.Application.UseCase.Transactions.Deposit
{
    public interface IDepositHandler
    {
        public Task<DepositViewDTO> HandleAsync(DepositInputDTO dto);
    }
}
