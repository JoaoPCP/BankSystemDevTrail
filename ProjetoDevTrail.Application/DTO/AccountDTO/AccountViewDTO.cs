namespace ProjetoDevTrail.Application.DTO.AccountDTO
{
    public class AccountViewDTO
    {
        public Guid Id { get; }
        public string OwnerName { get; }
        public string OwnerCPF { get; }

        public string AccountType { get; }
        public Decimal Balance { get; }

        public AccountViewDTO(
            Guid id,
            string ownerName,
            string ownerCPF,
            string accountType,
            Decimal balance
        )
        {
            Id = id;
            OwnerName = ownerName;
            OwnerCPF = ownerCPF;
            AccountType = accountType;
            Balance = balance;
        }
    }
}
