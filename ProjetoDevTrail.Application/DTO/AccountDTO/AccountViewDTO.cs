namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class AccountViewDTO
    {
        public Guid Id { get; }
        public string Number { get; }
        public string OwnerName { get; }
        public string OwnerCPF { get; }
        public string AccountType { get; }
        public string AccountStatus { get; }
        public Decimal Balance { get; }

        public AccountViewDTO(
            Guid id,
            string number,
            string ownerName,
            string ownerCPF,
            string accountType,
            string accountStatus,
            Decimal balance
        )
        {
            Id = id;
            Number = number;
            OwnerName = ownerName;
            OwnerCPF = ownerCPF;
            AccountType = accountType;
            AccountStatus = accountStatus;
            Balance = balance;
        }
    }
}
