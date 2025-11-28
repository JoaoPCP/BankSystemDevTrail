using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Application.UseCase.Transactions.Deposit;
using ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionById;

namespace ProjetoDevTrail.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpPost("/deposit")]
        public async Task<IActionResult> Deposit(
            [FromBody] DepositInputDTO dto,
            [FromServices] IDepositHandler handler
        )
        {
            DepositViewDTO result = await handler.HandleAsync(dto);
            return CreatedAtAction(nameof(GetTransactionById), new { id = result.Id }, result);
        }

        [HttpGet("/transaction/{id}")]
        public async Task<IActionResult> GetTransactionById(
            [FromRoute] Guid id,
            [FromServices] IGetTransactionByIdHandler handler
        )
        {
            TransactionViewDTO result = await handler.HandleAsync(id);
            return Ok(result);
        }
    }
}
