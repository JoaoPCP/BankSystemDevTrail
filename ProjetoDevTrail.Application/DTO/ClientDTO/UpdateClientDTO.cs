namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class UpdateClientDTO
    {
        public string Name { get; }
        public string Email { get; }

        public DateTime BirthDate { get; }

        public UpdateClientDTO(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
