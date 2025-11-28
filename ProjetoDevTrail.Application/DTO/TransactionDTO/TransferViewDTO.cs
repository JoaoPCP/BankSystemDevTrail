using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class TransferViewDTO : TransactionViewDTO
    {
        public string OriginAccountNumber { get; set; }
        public string DestinationAccountNumber { get; set; }

        public TransferViewDTO(
            Guid id,
            decimal amount,
            DateTime transactionDate,
            string originAccountNumber,
            string destinationAccountNumber
        )
            : base(id, TransactionType.Transferencia.ToString(), amount, transactionDate)
        {
            OriginAccountNumber = originAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
        }
    }
}
