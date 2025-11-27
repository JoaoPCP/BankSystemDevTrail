using ProjetoDevTrail.Application.DTO.AccountDTO;

namespace ProjetoDevTrail.Application.UseCase.Accounts.GetAccountById
{
    public interface IGetAccountByIdHandler
    {
        Task<AccountViewDTO> HandleAsync(Guid id);
    }
}
