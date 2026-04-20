using Application.Takmicenja;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TakmicenjeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakmicenjeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
         public async Task<ActionResult<List<Takmicenje>>> List()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Takmicenje>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }
    }
}