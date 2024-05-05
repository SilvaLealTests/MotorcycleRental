using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycles;

public class CreateMotorcyclesCommandHandler(
    IMotocyclesRepository repository,
    ILogger<CreateMotorcyclesCommandHandler> logger,
    IMapper mapper) : IRequestHandler<CreateMotorcyclesCommand, int>
{
    public async Task<int> Handle(CreateMotorcyclesCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new motorcycle");

        var motorcycle = mapper.Map<Motorcycle>(request);

        int id = await repository.Create(motorcycle);

        return id;
    }
}
