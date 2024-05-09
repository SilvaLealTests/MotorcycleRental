﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.RentalPlans.Queries.GetRentalPlanById;
using MotorcycleRental.Application.RentPlans.Commands.CreateRentPlan;
using MotorcycleRental.Application.RentPlans.Commands.DeleteRentPlan;
using MotorcycleRental.Application.RentPlans.Commands.UpdateRentPlan;
using MotorcycleRental.Application.RentPlans.Dtos;
using MotorcycleRental.Application.RentPlans.Queries.GetAllRentPlans;
using MotorcycleRental.Domain.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotorcycleRental.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RentalPlansController(IMediator mediator) : ControllerBase
    {
        [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Biker}")]       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentPlanDto>>> GetAll()
        {
            var rentalPlans = await mediator.Send(new GetAllRentPlansQuery());

            return Ok(rentalPlans);
            
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
        public async Task<ActionResult<RentPlanDto?>> GetById(int id)
        {
            var rentalPlan = await mediator.Send(new GetRentalPlanByIdQuery(id));

            return Ok(rentalPlan);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRentPlanCommand command)
        {
            int id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRentPlanCommand command)
        {
            command.Id = id;
            await mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = UserRoles.Admin)]
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
