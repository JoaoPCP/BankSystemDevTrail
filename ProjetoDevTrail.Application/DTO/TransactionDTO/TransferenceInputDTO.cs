using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class TransferenceInputDTO
    {
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }
        public string OriginAccountNumber { get; }
        public string DestinationAccountNumber { get; }

        public TransferenceInputDTO(
            decimal amount,
            string originAccountNumber,
            string destinationAccountNumber
        )
        {
            Amount = amount;
            OriginAccountNumber = originAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
        }
    }
}
