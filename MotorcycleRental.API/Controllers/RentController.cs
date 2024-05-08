using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Rents.Commands.CreateRent;
using MotorcycleRental.Application.Rents.Queries.CheckRentValue;
using MotorcycleRental.Application.Rents.Queries.GetRentById;
using MotorcycleRental.Domain.Constants;

namespace MotorcycleRental.API.Controllers
{
    [Authorize(Roles = UserRoles.Biker)]
    [Route("api/rent")]
    [ApiController]
    public class RentController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateRentCommand commad) { 
            var id = await mediator.Send(commad);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        
        [HttpGet("checkRentValue")]
        public async Task<ActionResult> CheckValue(CheckRentValueQuery query)
        {
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var rent = await mediator.Send(new GetRentByIdQuery(id));

                return Ok(rent);
        }
    }
}
