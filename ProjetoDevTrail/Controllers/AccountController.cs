using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount;
using ProjetoDevTrail.Application.UseCase.Accounts.DeleteAccount;
using ProjetoDevTrail.Application.UseCase.Accounts.GetAccountById;
using ProjetoDevTrail.Application.UseCase.Accounts.GetAllAccounts;
using ProjetoDevTrail.Application.UseCase.Accounts.GetByClient;
using ProjetoDevTrail.Application.UseCase.Accounts.UpdateAccount;
using ProjetoDevTrail.Application.UseCase.Clients.GetClientByCPF;

namespace ProjetoDevTrail.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAccount(
            [FromServices] ICreateAccountHandler handler,
            IGetClientByCPFHandler getClientByCPFHandler,
            [FromBody] CreateAccountDTO dto
        )
        {
            var owner = await getClientByCPFHandler.HandleAsync(dto.OwnerCPF);
            var response = await handler.HandleAsync(owner, dto);
            return CreatedAtAction(nameof(GetAccountById), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts(
            [FromServices] IGetAllAccountsHandler handler
        )
        {
            var response = await handler.HandleAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAccountById(
            [FromServices] IGetAccountByIdHandler handler,
            [FromRoute] Guid id
        )
        {
            var result = await handler.HandleAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAccount(
            [FromServices] IUpdateAccountHandler handler,
            [FromRoute] Guid id,
            [FromBody] UpdateAccountByEndpointDTO dto
        )
        {
            var response = await handler.HandleAsync(id, dto);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAccount(
            [FromServices] IDeleteAccountHandler handler,
            [FromRoute] Guid id
        )
        {
            await handler.HandleAsync(id);
            return Ok(new { message = "conta deletada com sucesso" });
        }

        [HttpGet("client/{clientCPF}")]
        public async Task<IActionResult> GetAccountsByClientId(
            [FromServices] IGetAccountByClientHandler getAccountByClientHandler,
            [FromServices] IGetClientByCPFHandler getClientByCPFHandler,
            [FromRoute] string clientCPF
        )
        {
            ClientViewDTO client = await getClientByCPFHandler.HandleAsync(clientCPF);
            List<AccountInListViewDTO> clientAccounts = await getAccountByClientHandler.HandleAsync(
                client.Id
            );
            return Ok(
                new
                {
                    Client = client.Name,
                    clientCPF = client.CPF,
                    accounts = clientAccounts,
                }
            );
        }
    }
}
