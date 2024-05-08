using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    public interface IRentRepository
    {
        Task<int> Create(Rent entity);

        Task<Rent?> GetActiveRentByBiker(int bikerId);
    }
}
