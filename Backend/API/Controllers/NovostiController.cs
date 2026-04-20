using Application.Novosti;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovostiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NovostiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Novost>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Novost>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Create.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }
    }
}