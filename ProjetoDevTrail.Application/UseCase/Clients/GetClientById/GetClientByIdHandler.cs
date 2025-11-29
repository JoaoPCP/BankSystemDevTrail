using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Application.UseCase.Clients.GetClientById
{
    public class GetClientByIdHandler(IClientRepository repo) : IGetClientByIdHandler
    {
        private readonly IClientRepository _repo = repo;

        public async Task<ClientViewDTO> HandleAsync(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result is null)
                throw new NotFoundException("Cliente não encontrado");
            return new ClientViewDTO(
                result.Id,
                result.Name,
                result.Email,
                result.CPF,
                result.BirthDate
            );
        }
    }
}
