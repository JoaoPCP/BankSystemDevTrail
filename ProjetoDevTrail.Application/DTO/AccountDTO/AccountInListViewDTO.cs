namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class AccountInListViewDTO
    {
        public Guid Id { get; }
        public string Number { get; }
        public string AccountType { get; }
        public string AccountStatus { get; }
        public Decimal Balance { get; }

        public AccountInListViewDTO(
            Guid id,
            string number,
            string accountType,
            string accountStatus,
            Decimal balance
        )
        {
            Id = id;
            Number = number;
            AccountType = accountType;
            AccountStatus = accountStatus;
            Balance = balance;
        }
    }
}
