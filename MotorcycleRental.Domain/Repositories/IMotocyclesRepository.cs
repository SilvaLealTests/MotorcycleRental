using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Infrastructure.Repositories
{
    public interface IMotocyclesRepository
    {
        Task<IEnumerable<Motorcycle>> GetAllAsync();
    }
}