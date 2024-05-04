using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Seeders
{
    internal class MotorcycleRentalSeeder(MotorcycleRentalDbContext dbContext) : IMotorcycleRentalSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Motorcycles.Any())
                {
                    var motorcycles = getMotorcycles();
                    dbContext.Motorcycles.AddRange(motorcycles);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Roles.Any())
                {
                    var roles = getRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }

                //if (dbContext.Users.Any())
                //{
                //    var users = getUsers();
                //    dbContext.Users.AddRange(users);
                //    await dbContext.SaveChangesAsync();
                //}
            }
        }

        private IEnumerable<IdentityRole> getRoles()
        {
            List<IdentityRole> roles = [
                new(UserRoles.Admin){
                    NormalizedName = UserRoles.Admin.ToUpper()
                },
                new(UserRoles.Biker){
                    NormalizedName = UserRoles.Biker.ToUpper()
                }
                ];

            return roles;
        }

        private IEnumerable<Motorcycle> getMotorcycles()
        {
            List<Motorcycle> motorcycles = [
                new()
                {
                    Id = 1,
                    Model = "Honda CB 300",
                    Year =  2023,
                    LicensePlate = "ABC-1A23"
                },
                new()
                {
                    Id = 2,
                    Model = "Yamaha Factor 125",
                    Year =  2021,
                    LicensePlate = "ABC-1B23"
                }
                ];
            return motorcycles;
        }
    }
}
