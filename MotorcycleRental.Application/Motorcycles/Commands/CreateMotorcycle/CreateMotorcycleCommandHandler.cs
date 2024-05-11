using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.Interfaces;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle;

public class CreateMotorcycleCommandHandler(
    IMotorcyclesRepository repository,
    ILogger<CreateMotorcycleCommandHandler> logger,
    IMapper mapper,
    IMessageQueueService messageQueueService) : IRequestHandler<CreateMotorcycleCommand, int>
{
    public async Task<int> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new motorcycle");

        var motorcycle = mapper.Map<Motorcycle>(request);

        //**criar validação para caso ja exista moto com mesma licença

        int id = await repository.Create(motorcycle);

        //Generate Event to Message Broker RabbitMQ...
        messageQueueService.Publish(motorcycle);

        return id;
    }
}
