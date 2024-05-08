using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Rents.Commands.CreateRent;
using MotorcycleRental.Application.Rents.Queries.CheckRentValue;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class RentController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateRentCommand commad) { 
            var result = await mediator.Send(commad);
            return Ok(result);
        }

        
        [HttpGet("checkRentValue")]
        public async Task<ActionResult> CheckValue(CheckRentValueQuery query)
        {
            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
