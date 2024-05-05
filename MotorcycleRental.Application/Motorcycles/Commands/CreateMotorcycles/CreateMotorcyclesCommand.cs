using MediatR;

namespace MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycles
{
    public class CreateMotorcyclesCommand : IRequest<int>
    {
        public int Year { get; set; }

        public string Model { get; set; } = default!;

        public string LicensePlate { get; set; } = default!;
    }
}
