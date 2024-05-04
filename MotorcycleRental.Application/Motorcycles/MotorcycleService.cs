using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles;

public class MotorcycleService(ILogger<MotorcycleService> logger, IMotocyclesRepository repository)
{
    public async Task<IEnumerable<Motorcycle>> getAll()
    {
        return await repository.GetAllAsync();
    }
}
