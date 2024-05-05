using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.RentalPlans.Commands.CreateRentalPlan;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.RentalPlans.Commands.UpdateRentalPlan
{
    public class UpdateRentalPlanCommandHandler(
         IRentalPlansRepository repository,
        ILogger<CreateRentalPlanCommandHandler> logger,
        IMapper mapper
        ) : IRequestHandler<UpdateRentalPlanCommand>
    {
        public async Task Handle(UpdateRentalPlanCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating RentalPlan with id {RentalPlanId} with {@UpdateRentalPlan}",
                request.Id,request);

            var rentalPlan = await repository.GetByIdAsync(request.Id);
            if (rentalPlan is null)
                throw new NotFoundException(nameof(RentalPlan), request.Id.ToString());

            //if (!rentalPlanAuthorizationService.Authorize(rentalPlan, ResourceOperation.Update))
            //    throw new ForbidException();

            mapper.Map(request, rentalPlan);            

            await repository.SaveChanges();
        }
    }
}
