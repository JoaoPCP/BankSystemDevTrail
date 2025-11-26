using ProjetoDevTrail.Domain.Commons;

namespace ProjetoDevTrail.Domain.Entities
{
    public class Client : BaseEntity
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

        private Client(Guid id, string name, string email, string cpf, DateTime birthDate)
            : base(id)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            BirthDate = birthDate;
            CreatedAt = DateTime.UtcNow;
        }

        public static Client Create(string name, string email, string cpf, DateTime birthDate)
        {
            return new Client(Guid.NewGuid(), name, email, cpf, birthDate);
        }
    }
}
