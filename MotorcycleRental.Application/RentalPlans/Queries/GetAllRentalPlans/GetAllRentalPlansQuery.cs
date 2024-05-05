using MediatR;
using MotorcycleRental.Application.RentalPlans.Dtos;

namespace MotorcycleRental.Application.RentalPlans.Queries.GetAllRentalPlans
{
    public class GetAllRentalPlansQuery : IRequest<IEnumerable<RentalPlanDto>>
    {
    }
}
