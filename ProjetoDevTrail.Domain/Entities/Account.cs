using ProjetoDevTrail.Domain.Commons;
using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Numero { get; set; } = string.Empty;
        public Client? Owner { get; set; } = null;
        public Guid OwnerID { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Balance { get; private set; }
        public AccountType Type { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Ativa;

        public List<Transaction> IngoingTransactions { get; } = new List<Transaction>();
        public List<Transaction> OutgoingTransactions { get; } = new List<Transaction>();

        public IEnumerable<Transaction> Transactions
        {
            get { return IngoingTransactions.Concat(OutgoingTransactions); }
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
            Numero = numero;
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

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor do depósito deve ser maior que zero");
            }
            Balance += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor do saque deve ser maior que zero");
            }
            if (valor > Balance)
            {
                throw new Exception("Saldo insuficiente para o saque");
            }
            Balance -= valor;
        }
    }
}
