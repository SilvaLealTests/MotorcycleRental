using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.RentalPlans.Dtos;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.RentalPlans.Queries.GetAllRentalPlans
{
    public class GetAllRentalPlansQueryHandler(
        IRentalPlansRepository repository,
        ILogger<GetAllRentalPlansQueryHandler> logger,
        IMapper mapper
        ) : IRequestHandler<GetAllRentalPlansQuery, IEnumerable<RentalPlanDto>>
    {
        public async Task<IEnumerable<RentalPlanDto>> Handle(GetAllRentalPlansQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Rental Plans");

            var rentalPlans = await repository.GetAllByAsync();

            var rentalPlanDtos = mapper.Map<IEnumerable<RentalPlanDto>>(rentalPlans);

            return rentalPlanDtos;

        }
    }
}
