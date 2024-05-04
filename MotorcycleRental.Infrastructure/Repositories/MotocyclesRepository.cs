using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class MotocyclesRepository(MotorcycleRentalDbContext dbContext) : IMotocyclesRepository
    {
        public async Task<IEnumerable<Motorcycle>> GetAllAsync()
        {
            var restaurants = await dbContext.Motorcycles.ToListAsync();
            return restaurants;
        }

    }
}
