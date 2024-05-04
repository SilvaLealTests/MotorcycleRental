using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    internal interface IMotocyclesRepository
    {
        Task<IEnumerable<Motorcycle>> GetAllAsync();
    }
}