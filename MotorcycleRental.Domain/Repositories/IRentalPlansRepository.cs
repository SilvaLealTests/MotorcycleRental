using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    public interface IRentalPlansRepository
    {
        Task<IEnumerable<RentalPlan>> GetAllByAsync();

        Task<RentalPlan?> GetByIdAsync(int id);

        Task<int> Create(RentalPlan entity);

        Task Delete(RentalPlan entity);

        Task SaveChanges();


    }
}
