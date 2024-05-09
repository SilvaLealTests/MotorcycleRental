using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class BikersRepository(MotorcycleRentalDbContext dbContext) : IBikersRepository
    {
        public async Task<Biker?> GetByIdAsync(int Id)
        {
            var biker = await dbContext.Bikers.FirstOrDefaultAsync(x => x.Id == Id);

            return biker;
        }

        public async Task<Biker?> GetByUserIdAsync(string UserId)
        {
            var biker = await dbContext.Bikers.FirstOrDefaultAsync(x => x.UserId == UserId);

            return biker;
        }
    }
}
