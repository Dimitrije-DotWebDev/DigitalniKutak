using Application.Sekcije;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SekcijeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SekcijeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sekcija>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Sekcija>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Create.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}