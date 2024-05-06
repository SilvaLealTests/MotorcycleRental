using MediatR;

namespace MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle
{
    public class UpdateMotorcycleCommand : IRequest
    {
        public int Id { get; set; }

        public string Description { get; set; } = default!;
        public int Year { get; set; }

        public int Model { get; set; } = default!;

        public string LicensePlate { get; set; } = default!;
    }
}
