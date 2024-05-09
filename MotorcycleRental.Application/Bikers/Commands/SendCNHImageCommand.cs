using MediatR;
using Microsoft.AspNetCore.Http;

namespace MotorcycleRental.Application.Bikers.Commands
{
    public class SendCNHImageCommand : IRequest<bool>
    {
        public IFormFile CNHImage { get; set; } = default!;
    }
}
