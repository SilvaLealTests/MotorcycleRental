using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle
{
    public class UpdateMotorcycleCommandHandler(
    IMotocyclesRepository repository,
    ILogger<CreateMotorcycleCommandHandler> logger,
    IMapper mapper) : IRequestHandler<UpdateMotorcycleCommand>
    {
        public async Task Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating Motorcycle with id {MotorcycleId} with {@UpdateMotorcycle}",
               request.Id, request);

            var motorcycle = await repository.GetByIdAsync(request.Id);
            if (motorcycle is null)
                throw new NotFoundException(nameof(Motorcycle), request.Id.ToString());

            //if (!rentalPlanAuthorizationService.Authorize(rentalPlan, ResourceOperation.Update))
            //    throw new ForbidException();

            mapper.Map(request, motorcycle);

            await repository.SaveChanges();
        }
    }
}
