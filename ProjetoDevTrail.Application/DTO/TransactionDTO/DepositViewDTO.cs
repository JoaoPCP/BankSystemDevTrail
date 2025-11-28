using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class DepositViewDTO : TransactionViewDTO
    {
        public string AccountNumber { get; set; }

        public DepositViewDTO(Guid id, string Number, decimal amount, DateTime transactionDate)
            : base(id, TransactionType.Deposito.ToString(), amount, transactionDate)
        {
            AccountNumber = Number;
        }
    }
}
