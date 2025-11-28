namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class DepositInputDTO
    {
        public string accountNumber { get; }
        public decimal Value { get; }

        public DepositInputDTO(string accountNumber, decimal value)
        {
            this.accountNumber = accountNumber;
            Value = value;
        }
    }
}
