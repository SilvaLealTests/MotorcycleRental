using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Auth.Commands.Authentication;
using MotorcycleRental.Application.Users.Commands.AdminRegister;
using MotorcycleRental.Application.Users.Commands.BikerRegister;
using MotorcycleRental.Domain.Constants;

namespace MotorcycleRental.API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("bikerRegister")]        
        public async Task<ActionResult> BikerRegister(BikerRegisterCommand command) {

           var result = await mediator.Send(command);

            return Ok(result);
            
        }

        
        [HttpPost("adminRegister")]
        public async Task<ActionResult> AdminRegister(AdminRegisterCommand command)
        {
            var result = await mediator.Send(command); 
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthenticationCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

    }
}
