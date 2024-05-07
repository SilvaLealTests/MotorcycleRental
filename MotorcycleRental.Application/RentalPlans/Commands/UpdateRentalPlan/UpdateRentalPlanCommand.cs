using MediatR;

namespace MotorcycleRental.Application.RentalPlans.Commands.UpdateRentalPlan
{
    public class UpdateRentalPlanCommand : IRequest
    {
        public int Id { get; set; }


        public string Description { get; set; } = default!;


        public int Days { get; set; }


        public decimal Cost { get; set; }
    }
}
