using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class RentalPlansRepository(MotorcycleRentalDbContext dbContext) : IRentalPlansRepository
    {
        public async Task<int> Create(RentalPlan entity)
        {
            dbContext.RentalPlans.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(RentalPlan entity)
        {
            dbContext.RentalPlans.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RentalPlan>> GetAllByAsync()
        {
            var rentalPlans = await dbContext.RentalPlans.ToListAsync();            
            return rentalPlans;
        }

        public async Task<RentalPlan?> GetByIdAsync(int id)
        {
            var rentalPlan = await dbContext.RentalPlans.FirstOrDefaultAsync(x => x.Id == id);
            return rentalPlan;
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
    }
}
