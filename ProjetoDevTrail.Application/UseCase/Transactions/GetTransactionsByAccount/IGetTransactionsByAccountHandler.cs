using ProjetoDevTrail.Application.DTO.TransactionDTO;

namespace ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionsByAccount
{
    public interface IGetTransactionsByAccountHandler
    {
        public Task<List<TransactionViewDTO>> HandleAsync(Guid accountID);
    }
}
