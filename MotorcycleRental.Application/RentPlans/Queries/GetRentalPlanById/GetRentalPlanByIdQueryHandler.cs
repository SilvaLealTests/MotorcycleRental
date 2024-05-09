using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.RentPlans.Dtos;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.RentalPlans.Queries.GetRentalPlanById
{
    public class GetRentalPlanByIdQueryHandler(
        IRentPlansRepository repository,
        ILogger<GetRentalPlanByIdQueryHandler> logger,
        IMapper mapper
        ) : IRequestHandler<GetRentalPlanByIdQuery, RentPlanDto>
    {
        public async Task<RentPlanDto> Handle(GetRentalPlanByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Rental Plan By Id: {RentalPlaId}",request.Id);

            var rentalPlan = await repository.GetByIdAsync(request.Id);

            return mapper.Map<RentPlanDto>( rentalPlan );
        }
    }
}
