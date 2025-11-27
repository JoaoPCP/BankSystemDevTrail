using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.DTO.AccountDTO;
using ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount;

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
            return Ok(response);
            //return CreatedAtAction(nameof(GetAccountById), new { id = response.Id }, response);
        }
    }
}
