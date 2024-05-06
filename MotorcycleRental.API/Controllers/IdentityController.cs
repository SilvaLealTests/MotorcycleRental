using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Users.Commands.BikerRegister;

namespace MotorcycleRental.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPost("bikerRegister")]        
        public async Task<ActionResult> BikerRegister(BikerRegisterCommand command) {

           var result = await mediator.Send(command);

            return Ok(result);
            
        }
    }
}
