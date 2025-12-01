using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class UpdateClientDTO
    {
        public string Name { get; }

        [EmailAddress(ErrorMessage = "O email informado não é válido.")]]
        public string Email { get; }

        public DateOnly BirthDate { get; }

        public UpdateClientDTO(string name, string email, DateOnly birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
