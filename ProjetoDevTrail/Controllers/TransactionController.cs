using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Application.UseCase.Transactions.Deposit;
using ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionById;
using ProjetoDevTrail.Application.UseCase.Transactions.Transfer;
using ProjetoDevTrail.Application.UseCase.Transactions.Withdraw;

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

        [HttpPost("/withdraw")]
        public async Task<IActionResult> Withdraw(
            [FromBody] WithdrawInputDTO dto,
            [FromServices] IWithdrawHandler handler
        )
        {
            WithdrawViewDTO result = await handler.HandleAsync(dto);
            return CreatedAtAction(nameof(GetTransactionById), new { id = result.Id }, result);
        }

        [HttpPost("/transfer")]
        public async Task<IActionResult> Transfer(
            [FromBody] TransferenceInputDTO dto,
            [FromServices] ITransferenceHandler handler
        )
        {
            TransferenceViewDTO result = await handler.HandleAsync(dto);
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
