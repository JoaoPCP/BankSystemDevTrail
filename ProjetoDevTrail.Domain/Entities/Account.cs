using ProjetoDevTrail.Domain.Commons;
using ProjetoDevTrail.Domain.Enum.Account;

namespace ProjetoDevTrail.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Numero { get; set; } = string.Empty;
        public Client Owner { get; set; } = null!; //para o construtor privado
        public Guid OwnerID { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Saldo { get; private set; }
        public AccountType Tipo { get; set; }
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
            Client owner,
            decimal saldo,
            AccountType tipo,
            AccountStatus status,
            DateTime createdAt,
            DateTime? updatedAt
        )
            : base(id)
        {
            Numero = numero;
            OwnerID = owner.Id;
            Owner = owner;
            Saldo = saldo;
            Tipo = tipo;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Account Create(
            string numero,
            Client titular,
            AccountType tipo,
            AccountStatus status
        )
        {
            return new Account(
                id: Guid.NewGuid(),
                numero: numero,
                owner: titular,
                tipo: tipo,
                status: AccountStatus.Ativa,
                createdAt: DateTime.Now,
                updatedAt: null,
                saldo: 0
            );
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor do depósito deve ser maior que zero");
            }
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor do saque deve ser maior que zero");
            }
            if (valor > Saldo)
            {
                throw new Exception("Saldo insuficiente para o saque");
            }
            Saldo -= valor;
        }
    }
}
