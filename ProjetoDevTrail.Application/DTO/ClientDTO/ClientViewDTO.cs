using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class ClientViewDTO
    {
        public Guid Id { get; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(
            @"\d{3}\.\d{3}\.\d{3}-\d{2}",
            ErrorMessage = "O CPF informado não é válido."
        )]
        public string CPF { get; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
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
