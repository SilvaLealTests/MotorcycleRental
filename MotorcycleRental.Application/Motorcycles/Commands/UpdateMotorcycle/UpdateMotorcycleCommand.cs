using MediatR;

namespace MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle
{
    public class UpdateMotorcycleCommand : IRequest
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Model { get; set; } = default!;

        public string LicensePlate { get; set; } = default!;
    }
}
