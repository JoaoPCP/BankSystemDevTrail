namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class WithdrawViewDTO : TransactionViewDTO
    {
        public string originAccountNumber { get; }

        public WithdrawViewDTO(
            Guid id,
            decimal amount,
            DateTime transactionDate,
            string originAccountNumber
        )
            : base(
                id,
                Domain.Enum.Transaction.TransactionType.Saque.ToString(),
                amount,
                transactionDate
            )
        {
            this.originAccountNumber = originAccountNumber;
        }
    }
}
