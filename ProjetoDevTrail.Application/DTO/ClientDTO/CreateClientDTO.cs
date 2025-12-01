using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class CreateClientDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
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
