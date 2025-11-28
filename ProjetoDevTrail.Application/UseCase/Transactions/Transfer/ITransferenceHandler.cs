using ProjetoDevTrail.Application.DTO.TransactionDTO;

namespace ProjetoDevTrail.Application.UseCase.Transactions.Transfer
{
    public interface ITransferenceHandler
    {
        public Task<TransferenceViewDTO> HandleAsync(TransferenceInputDTO dto);
    }
}
