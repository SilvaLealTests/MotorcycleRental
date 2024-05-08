using MediatR;

namespace MotorcycleRental.Application.Rents.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<int>
    {
        public int RentalPlanId { get; set; } = new();

        public int BikerId { get; set; } = new();

        public int MotorcycleId { get; set; } = new();

        public DateTime InitialDate { get; set; }

        public DateTime PreviewDate { get; set; }
    }
}
