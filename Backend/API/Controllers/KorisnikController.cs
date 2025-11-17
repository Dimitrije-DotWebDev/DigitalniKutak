using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Korisnici;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KorisnikController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KorisnikController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<KorisnikDTO>> Login(Login.Query query)
        {
            return await _mediator.Send(query);
        }
        [HttpPost("register")]
        public async Task<ActionResult<KorisnikDTO>> Register(Register.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}