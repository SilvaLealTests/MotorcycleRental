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

                if (!dbContext.RentalPlans.Any())
                {
                    var rentalPlans = getRentalPlans();
                    dbContext.RentalPlans.AddRange(rentalPlans);
                    await dbContext.SaveChangesAsync();
                }

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
            }
        }

        private IEnumerable<RentalPlan> getRentalPlans()
        {
            List<RentalPlan> rentalPlans = [
                new(){
                    Cost = 30,
                    Days = 7,
                    Description= "7 dias com um custo de R$30,00 por dia"
                },
                new(){
                    Cost = 28,
                    Days = 15,
                    Description= "15 dias com um custo de R$28,00 por dia"
                },
                new(){
                    Cost = 22,
                    Days = 30,
                    Description= "30 dias com um custo de R$22,00 por dia"
                },
                new(){
                    Cost = 20,
                    Days = 45,
                    Description= "45 dias com um custo de R$20,00 por dia"
                },
                new(){
                    Cost = 18,
                    Days = 50,
                    Description= "50 dias com um custo de R$18,00 por dia"
                }
                ];

            return rentalPlans;
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
                    Model = "Honda CB 300",
                    Year =  2023,
                    LicensePlate = "ABC-1A23"
                },
                new()
                {
                    Model = "Yamaha Factor 125",
                    Year =  2021,
                    LicensePlate = "ABC-1B23"
                }
                ];
            return motorcycles;
        }
    }
}
