namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class ClientViewDTO
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string CPF { get; }
        public DateOnly BirthDate { get; }

        public ClientViewDTO(Guid id, string name, string email, string cpf, DateOnly birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            CPF = cpf;
            BirthDate = birthDate;
        }
    }
}
