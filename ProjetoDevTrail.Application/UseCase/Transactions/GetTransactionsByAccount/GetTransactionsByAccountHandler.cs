using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Infra.Repositories.TransactionRepositories;

namespace ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionsByAccount
{
    public class GetTransactionsByAccountHandler(ITransactionRepository repo)
        : IGetTransactionsByAccountHandler
    {
        private readonly ITransactionRepository _repo = repo;

        public async Task<List<TransactionViewDTO>> HandleAsync(Guid accountID)
        {
            var result = await _repo.GetByAccountIdAsync(accountID);
            var transactions = result
                .Select(t =>
                {
                    TransactionViewDTO item = t;
                    return item;
                })
                .ToList();
            return transactions;
        }
    }
}
