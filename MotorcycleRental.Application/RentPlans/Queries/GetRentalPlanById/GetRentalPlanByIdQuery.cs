using MediatR;
using MotorcycleRental.Application.RentPlans.Dtos;

namespace MotorcycleRental.Application.RentalPlans.Queries.GetRentalPlanById
{
    public class GetRentalPlanByIdQuery(int id) : IRequest<RentPlanDto>
    {
        public int Id { get; set; } = id;
    }
}
