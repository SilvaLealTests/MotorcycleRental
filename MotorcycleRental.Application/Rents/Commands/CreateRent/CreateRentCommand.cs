using MediatR;

namespace MotorcycleRental.Application.Rents.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<int>
    {
        public int RentPlanId { get; set; } = new();
               
        public int MotorcycleId { get; set; } = new();

    }
}
