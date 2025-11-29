using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Infra.Repositories.TransactionRepositories;

namespace ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionById
{
    public class GetTransactionByIdHandler(ITransactionRepository transRepo)
        : IGetTransactionByIdHandler
    {
        private readonly ITransactionRepository _transRepo = transRepo;

        public async Task<TransactionViewDTO> HandleAsync(Guid id)
        {
            var transaction = await _transRepo.GetByIdAsync(id);
            if (transaction == null)
                throw new NotFoundException("Transação não encontrada");
            TransactionViewDTO result = transaction;
            return result;
        }
    }
}
