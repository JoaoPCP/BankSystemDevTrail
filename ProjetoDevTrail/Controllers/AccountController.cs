using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount;
using ProjetoDevTrail.Application.UseCase.Accounts.GetAccountById;
using ProjetoDevTrail.Application.UseCase.Accounts.GetAllAccounts;

namespace ProjetoDevTrail.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAccount(
            [FromServices] ICreateAccountHandler handler,
            [FromBody] CreateAccountDTO dto
        )
        {
            var response = await handler.HandleAsync(dto);
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
    }
}
