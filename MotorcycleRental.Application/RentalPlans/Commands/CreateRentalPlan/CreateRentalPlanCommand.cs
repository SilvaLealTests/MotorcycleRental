using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRental.Application.RentalPlans.Commands.CreateRentalPlan
{
    public class CreateRentalPlanCommand : IRequest<int>
    {
       
        public string Description { get; set; } = default!;

       
        public int Days { get; set; }

        
        public decimal Cost { get; set; }
    }
}
