using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Bikers.Commands;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadPhotoTest(IMediator mediator) : ControllerBase
    {
        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadImage([FromForm] SendCNHImageCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
