namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class WithdrawInputDTO
    {
        public string accountNumber { get; }
        public decimal Value { get; }

        public WithdrawInputDTO(string accountNumber, decimal value)
        {
            this.accountNumber = accountNumber;
            Value = value;
        }
    }
}
