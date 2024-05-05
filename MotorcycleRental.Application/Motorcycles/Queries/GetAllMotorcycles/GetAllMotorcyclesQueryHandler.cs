using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.Motorcycles.Dtos;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles.Queries.GetAllMotorcycles
{
    public class GetAllMotorcyclesQueryHandler(
        IMotocyclesRepository repository,
        ILogger<GetAllMotorcyclesQueryHandler> logger,
        IMapper mapper
        ) : IRequestHandler<GetAllMotorcyclesQuery,IEnumerable<MotorcycleDto>>
    {
        

        public async Task<IEnumerable<MotorcycleDto>> Handle(GetAllMotorcyclesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all motorcycles");
            var motorcycles = await repository.GetAllAsync();

            var motorcyclesDtos = mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles);

            return motorcyclesDtos;
        }
    }
}
