namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class CreateClientDTO
    {
        public string Name { get; }
        public string Email { get; }
        public string CPF { get; }
        public DateOnly BirthDate { get; }

        public CreateClientDTO(string name, string email, string cpf, DateOnly birthDate)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            BirthDate = birthDate;
        }
    }
}
