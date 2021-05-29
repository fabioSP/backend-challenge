using MEChallenge.Application.Queries.Status;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MEChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("status")]
        public async Task<IActionResult> Status([FromBody] StatusQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
