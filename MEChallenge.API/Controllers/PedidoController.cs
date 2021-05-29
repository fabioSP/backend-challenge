using MEChallenge.Application.Commands.Pedido;
using MEChallenge.Application.Queries.Pedidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MEChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("pedido")]
        public async Task<IActionResult> Pedido()
        {
            var query = new PedidoListQuery();
            var response = await _mediator.Send(query).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPost("pedido")]
        public async Task<IActionResult> Pedido([FromBody] PedidoAddCommand cmd)
        {
            var response = await _mediator.Send(cmd).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPut("pedido")]
        public async Task<IActionResult> Pedido([FromBody] PedidoUpdateCommand cmd)
        {
            var response = await _mediator.Send(cmd).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpDelete("pedido")]
        public async Task<IActionResult> Pedido([FromBody] PedidoDeleteCommand cmd)
        {
            var response = await _mediator.Send(cmd).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
