using System.Text.Json.Serialization;
using ProjetoDevTrail.Application.DTO.AccountDTO;

namespace ProjetoDevTrail.Application.DTO.ClientDTO
{
    public class ClientWIthAccountViewDTO : ClientViewDTO
    {
        [JsonPropertyOrder(10)]
        public List<AccountInListViewDTO> Accounts { get; }

        public ClientWIthAccountViewDTO(
            Guid id,
            string name,
            string email,
            string cpf,
            DateOnly birthDate,
            List<AccountInListViewDTO> accounts
        )
            : base(id, name, email, cpf, birthDate)
        {
            Accounts = accounts;
        }

        public ClientWIthAccountViewDTO(ClientViewDTO client, List<AccountInListViewDTO> accounts)
            : this(client.Id, client.Name, client.Email, client.CPF, client.BirthDate, accounts) { }
    }
}
