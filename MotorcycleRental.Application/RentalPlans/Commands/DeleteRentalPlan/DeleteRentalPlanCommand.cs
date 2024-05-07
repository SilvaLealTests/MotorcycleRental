using MediatR;

namespace MotorcycleRental.Application.RentalPlans.Commands.DeleteRentalPlan
{
    public class DeleteRentalPlanCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
