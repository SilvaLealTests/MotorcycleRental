using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.RentalPlans.Commands.CreateRentalPlan
{
    public class CreateRentalPlanCommandHandler(
        IRentalPlansRepository repository,
        ILogger<CreateRentalPlanCommandHandler> logger,
        IMapper mapper
        ) : IRequestHandler<CreateRentalPlanCommand, int>
    {
        public async Task<int> Handle(CreateRentalPlanCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Creating a new Rental Plan: {request}");

            //do mapping
            var rentalPlan = mapper.Map<RentalPlan>(request);

            //insert
            return await repository.Create(rentalPlan);             

        }
    }
}
