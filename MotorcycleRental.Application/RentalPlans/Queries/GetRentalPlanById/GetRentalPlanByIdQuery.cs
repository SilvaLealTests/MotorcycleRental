using MediatR;
using MotorcycleRental.Application.RentalPlans.Dtos;

namespace MotorcycleRental.Application.RentalPlans.Queries.GetRentalPlanById
{
    public class GetRentalPlanByIdQuery(int id) : IRequest<RentalPlanDto>
    {
        public int Id { get; set; } = id;
    }
}
