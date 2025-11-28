using ProjetoDevTrail.Application.DTO.TransactionDTO;

namespace ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionById
{
    public interface IGetTransactionByIdHandler
    {
        Task<TransactionViewDTO> HandleAsync(Guid id);
    }
}
