using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycles;
using MotorcycleRental.Application.Motorcycles.Queries.GetAllMotorcycles;
using MotorcycleRental.Application.Motorcycles.Queries.GetMotorcycleById;

namespace MotorcycleRental.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController(IMediator mediator) : ControllerBase
    {
        // GET: api/<MotorcycleController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var motorcycles = await mediator.Send(new GetAllMotorcyclesQuery());

            return Ok(motorcycles);
        }

        // GET api/<MotorcycleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var motorcycle = await mediator.Send(new GetMotorcycleByIdQuery()
            {
                Id = id
            }
            );

            return Ok(motorcycle);
        }

        // POST api/<MotorcycleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMotorcyclesCommand command)
        {
            int id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        // PUT api/<MotorcycleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotorcycleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
