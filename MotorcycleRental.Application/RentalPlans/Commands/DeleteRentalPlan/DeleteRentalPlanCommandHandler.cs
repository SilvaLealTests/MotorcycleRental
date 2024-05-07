using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.RentalPlans.Commands.DeleteRentalPlan
{
    public class DeleteRentalPlanCommandHandler(
        IRentalPlansRepository repository,
        ILogger<DeleteRentalPlanCommandHandler> logger,
        IMapper mapper
        ) : IRequestHandler<DeleteRentalPlanCommand>
    {
        public async Task Handle(DeleteRentalPlanCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Removing Rental Plan with id: {RentalPlanId}",request.Id);

            var rentalPlan = await repository.GetByIdAsync(request.Id);

            if (rentalPlan is null)
                throw new NotFoundException(nameof(RentalPlan), request.Id.ToString());

            await repository.Delete(rentalPlan);               

            
        }
    }
}
