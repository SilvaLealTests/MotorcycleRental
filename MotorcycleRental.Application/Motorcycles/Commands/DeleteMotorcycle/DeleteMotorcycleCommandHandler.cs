using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles.Commands.DeleteMotorcycle
{
    public class DeleteMotorcycleCommandHandler(
        IMotorcyclesRepository repository,
        ILogger<DeleteMotorcycleCommandHandler> logger
        ) : IRequestHandler<DeleteMotorcycleCommand>
    {
        public async Task Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Removing Motorcycle with id: {MotorcycleId}", request.Id);

            var motorcycles = await repository.GetByIdAsync(request.Id);

            if (motorcycles is null)
                throw new NotFoundException(nameof(Motorcycle), request.Id.ToString());

            //verificar se tem locações

            await repository.Delete(motorcycles);


        }
    }
}
