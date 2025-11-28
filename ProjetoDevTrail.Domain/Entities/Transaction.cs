using ProjetoDevTrail.Domain.Commons;
using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid? OriginAccount_Id { get; set; }
        public Account? OriginAccount { get; set; } = null;
        public Guid? DestinationAccount_Id { get; set; }
        public Account? DestinationAccount { get; set; } = null;

        private Transaction() { }

        private Transaction(
            Guid id,
            TransactionType type,
            decimal amount,
            DateTime transactionDate,
            Guid? originAccount_Id,
            Account? originAccount,
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

        public static Transaction CreateDeposit(
            decimal amount,
            Guid destinationAccountId,
            DateTime transactionDate
        )
        {
            return new Transaction(
                id: Guid.NewGuid(),
                type: TransactionType.Deposito,
                amount: amount,
                transactionDate: transactionDate,
                originAccount_Id: null,
                originAccount: null,
                destinationAccount_Id: destinationAccountId,
                destinationAccount: null
            );
        }

        public static Transaction CreateWithdraw(
            decimal amount,
            Guid originAccount_Id,
            DateTime transactionDate
        )
        {
            return new Transaction(
                id: Guid.NewGuid(),
                type: TransactionType.Saque,
                amount: amount,
                transactionDate: transactionDate,
                originAccount_Id: originAccount_Id,
                originAccount: null,
                destinationAccount_Id: null,
                destinationAccount: null
            );
        }

        public static Transaction CreateTransfer(
            decimal amount,
            Guid originAccount_Id,
            Guid destinationAccount_Id,
            DateTime transactionDate
        )
        {
            return new Transaction(
                id: Guid.NewGuid(),
                type: TransactionType.Transferencia,
                amount: amount,
                transactionDate: transactionDate,
                originAccount_Id: originAccount_Id,
                originAccount: null,
                destinationAccount_Id: destinationAccount_Id,
                destinationAccount: null
            );
        }
    }
}
