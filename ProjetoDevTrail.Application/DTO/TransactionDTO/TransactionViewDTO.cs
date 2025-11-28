using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public abstract class TransactionViewDTO
    {
        public Guid Id { get; }
        public string Type { get; }
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }

        protected TransactionViewDTO(Guid id, string type, decimal amount, DateTime transactionDate)
        {
            Id = id;
            TransactionDate = transactionDate;
            Type = type;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public static implicit operator TransactionViewDTO(Transaction v)
        {
            switch (v.Type)
            {
                case TransactionType.Deposito:
                    return new DepositViewDTO(
                        v.Id,
                        v.DestinationAccount!.Number,
                        v.Amount,
                        v.TransactionDate
                    );
                case TransactionType.Saque:
                    return new WithdrawViewDTO(
                        v.Id,
                        v.Amount,
                        v.TransactionDate,
                        v.DestinationAccount!.Number
                    );
                case TransactionType.Transferencia:
                    return new TransferViewDTO(
                        v.Id,
                        v.Amount,
                        v.TransactionDate,
                        originAccountNumber: v.OriginAccount!.Number,
                        destinationAccountNumber: v.DestinationAccount!.Number
                    );
            }
            return null!;
        }
    }
}
