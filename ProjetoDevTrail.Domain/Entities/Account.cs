using System.ComponentModel.DataAnnotations.Schema;
using ProjetoDevTrail.Domain.Commons;
using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Number { get; set; } = string.Empty;
        public Client? Owner { get; set; } = null;
        public Guid OwnerID { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Balance { get; protected set; }
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Ativa;

        public List<Transaction> IngoingTransactions { get; } = new List<Transaction>();
        public List<Transaction> OutgoingTransactions { get; } = new List<Transaction>();

        [NotMapped]
        public IEnumerable<Transaction> Transactions
        {
            get { return IngoingTransactions.Concat(OutgoingTransactions).ToList(); }
        }

        private Account() { }

        private Account(
            Guid id,
            string numero,
            Guid ownerId,
            decimal saldo,
            AccountType tipo,
            AccountStatus status,
            DateTime createdAt,
            DateTime? updatedAt = null,
            Client? owner = null
        )
            : base(id)
        {
            Number = numero;
            OwnerID = ownerId;
            Owner = owner;
            Balance = saldo;
            Type = tipo;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Account Create(Guid ownerId, AccountType tipo)
        {
            string numero = new Random().Next(10000000, 99999999).ToString();
            return new Account(
                id: Guid.NewGuid(),
                numero: numero,
                ownerId: ownerId,
                tipo: tipo,
                status: AccountStatus.Ativa,
                createdAt: DateTime.Now,
                saldo: 0
            );
        }

        public void Deposit(decimal valor)
        {
            Balance += valor;
        }

        public bool Withdraw(decimal valor)
        {
            if (valor > Balance)
                return false;
            Balance -= valor;
            return true;
        }
    }
}
