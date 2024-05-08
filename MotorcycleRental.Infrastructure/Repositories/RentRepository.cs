using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class RentRepository(MotorcycleRentalDbContext dbContext) : IRentRepository
    {
        public async Task<int> Create(Rent entity)
        {
            dbContext.Rents.Add(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Rent?> GetActiveRentByBiker(int bikerId)
        {
            var list = await dbContext.Rents.Where(x => x.Biker.Id == bikerId && x.FinalDate == null).ToListAsync();

            return list.FirstOrDefault();
        }
    }
}
