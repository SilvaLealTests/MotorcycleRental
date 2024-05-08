using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    public interface IRentalPlansRepository
    {
        Task<IEnumerable<RentPlan>> GetAllByAsync();

        Task<RentPlan?> GetByIdAsync(int id);

        Task<int> Create(RentPlan entity);

        Task Delete(RentPlan entity);

        Task SaveChanges();


    }
}
