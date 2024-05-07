using AutoMapper;
using MotorcycleRental.Application.RentalPlans.Commands.CreateRentalPlan;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.RentalPlans.Dtos
{
    public class RentalPlanProfile : Profile
    {
        public RentalPlanProfile()
        {
            CreateMap<CreateRentalPlanCommand, RentalPlan>();

            CreateMap<RentalPlan, RentalPlanDto>();

        }
    }
}
