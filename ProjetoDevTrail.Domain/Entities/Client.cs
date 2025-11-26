namespace ProjetoDevTrail.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;

        public ICollection<Account> Accounts { get; } = new List<Account>();

        private Client() { }

        public Client(string name, string email, string cpf, DateTime birthDate)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            Id = Guid.NewGuid();
            BirthDate = birthDate;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
