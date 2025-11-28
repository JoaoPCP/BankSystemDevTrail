using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.DTO.ClientDTO;
using ProjetoDevTrail.Application.UseCase.Clients.CreateClient;
using ProjetoDevTrail.Application.UseCase.Clients.DeleteClient;
using ProjetoDevTrail.Application.UseCase.Clients.GetAllClients;
using ProjetoDevTrail.Application.UseCase.Clients.GetClientById;
using ProjetoDevTrail.Application.UseCase.Clients.UpdateClient;

namespace ProjetoDevTrail.Api.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateClient(
            [FromServices] ICreateClientHandler handler,
            [FromBody] CreateClientDTO dto
        )
        {
            var response = await handler.HandleAsync(dto);
            return CreatedAtAction(nameof(GetClientById), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetAllClientsHandler handler)
        {
            var result = await handler.HandleAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetClientById(
            [FromServices] IGetClientByIdHandler handler,
            [FromRoute] Guid id
        )
        {
            var result = await handler.HandleAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateClient(
            [FromServices] IUpdateClientHandler handler,
            [FromBody] UpdateClientDTO dto,
            [FromRoute] Guid id
        )
        {
            var response = await handler.HandleAsync(id, dto);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClient(
            [FromServices] IDeleteClientHandler handler,
            [FromRoute] Guid id
        )
        {
            await handler.HandleAsync(id);
            return Ok(new { message = "Cliente Deletado com sucesso" });
        }
    }
}
