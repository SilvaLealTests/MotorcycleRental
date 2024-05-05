using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.RentalPlans.Dtos;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.RentalPlans.Queries.GetRentalPlanById
{
    public class GetRentalPlanByIdQueryHandler(
        IRentalPlansRepository repository,
        ILogger<GetRentalPlanByIdQueryHandler> logger,
        IMapper mapper
        ) : IRequestHandler<GetRentalPlanByIdQuery, RentalPlanDto>
    {
        public async Task<RentalPlanDto> Handle(GetRentalPlanByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Rental Plan By Id: {RentalPlaId}",request.Id);

            var rentalPlan = await repository.GetByIdAsync(request.Id);

            return mapper.Map<RentalPlanDto>( rentalPlan );
        }
    }
}
