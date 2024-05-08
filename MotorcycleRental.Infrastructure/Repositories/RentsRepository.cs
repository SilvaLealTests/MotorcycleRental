using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class RentsRepository(MotorcycleRentalDbContext dbContext) : IRentsRepository
    {
        public async Task<int> Create(Rent entity)
        {
            dbContext.Rents.Add(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Rent?> GetActiveRentByBiker(int bikerId)
        {
            var list = await dbContext.Rents.Where(x => x.Biker.Id == bikerId && x.FinalDate == null)
                .Include(r => r.RentPlan).ToListAsync();

            return list.FirstOrDefault();
        }

        public async Task<Rent?> GetByIdAndByBikerIdAsync(int rentId,int bikerId)
        {
            var rent = await dbContext.Rents.Where(x => x.Id == rentId && x.BikerId == bikerId).ToListAsync();

            return rent.FirstOrDefault();
        }
    }
}
