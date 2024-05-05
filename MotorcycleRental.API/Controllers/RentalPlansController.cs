using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.RentalPlans.Commands.CreateRentalPlan;
using MotorcycleRental.Application.RentalPlans.Commands.DeleteRentalPlan;
using MotorcycleRental.Application.RentalPlans.Commands.UpdateRentalPlan;
using MotorcycleRental.Application.RentalPlans.Dtos;
using MotorcycleRental.Application.RentalPlans.Queries.GetAllRentalPlans;
using MotorcycleRental.Application.RentalPlans.Queries.GetRentalPlanById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalPlansController(IMediator mediator) : ControllerBase
    {
        // GET: api/<RentalPlansController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalPlanDto>>> GetAll()
        {
            var rentalPlans = await mediator.Send(new GetAllRentalPlansQuery());

            return Ok(rentalPlans);
            
        }

        // GET api/<RentalPlansController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalPlanDto?>> GetById(int id)
        {
            var rentalPlan = await mediator.Send(new GetRentalPlanByIdQuery(id));

            return Ok(rentalPlan);
        }

        // POST api/<RentalPlansController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRentalPlanCommand command)
        {
            int id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        // PUT api/<RentalPlansController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRentalPlanCommand command)
        {
            command.Id = id;
            await mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<RentalPlansController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteRentalPlanCommand(id));

            return NoContent();
        }
    }
}
