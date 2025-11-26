using ProjetoDevTrail.Domain.Commons;
using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid OriginAccount_Id { get; set; }
        public Account OriginAccount { get; set; } = null!;
        public Guid? DestinationAccount_Id { get; set; }
        public Account? DestinationAccount { get; set; }

        private Transaction() { }

        private Transaction(
            Guid id,
            TransactionType type,
            decimal amount,
            DateTime transactionDate,
            Guid originAccount_Id,
            Account originAccount,
            Guid? destinationAccount_Id,
            Account? destinationAccount
        )
            : base(id)
        {
            Amount = amount;
            Type = type;
            TransactionDate = transactionDate;
            OriginAccount_Id = originAccount_Id;
            OriginAccount = originAccount;
            DestinationAccount_Id = destinationAccount_Id;
            DestinationAccount = destinationAccount;
        }

        public static Transaction Create(
            TransactionType type,
            decimal amount,
            Guid originAccount_Id,
            Account originAccount,
            Guid? destinationAccount_Id = null,
            Account? destinationAccount = null
        )
        {
            return new Transaction(
                id: Guid.NewGuid(),
                type: type,
                amount: amount,
                transactionDate: DateTime.UtcNow,
                originAccount_Id: originAccount_Id,
                originAccount: originAccount,
                destinationAccount_Id: destinationAccount_Id,
                destinationAccount: destinationAccount
            );
        }
    }
}
