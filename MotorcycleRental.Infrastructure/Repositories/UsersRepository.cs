using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;
using MotorcycleRental.Infrastructure.Persistence;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class UsersRepository(
        UserManager<User> userManager,        
        MotorcycleRentalDbContext dbContext) : IUsersRepository
    {
        public async Task<bool> InsertAdmin(User entity, string password)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                var createUserResult = await userManager.CreateAsync(entity, password);
                if (!createUserResult.Succeeded)
                {
                    throw new Exception("Failed to create user");
                }
                
                var addToRoleResult = await userManager.AddToRoleAsync(entity, UserRoles.Admin);
                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception($"Failed to assign role: {UserRoles.Admin} to user");
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {

                await transaction.RollbackAsync();
                return false;
            }

        }
    

    public async Task<bool> InsertBiker(User entity, string password,Biker biker)
    {
        using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            var createUserResult = await userManager.CreateAsync(entity, password);
            if (!createUserResult.Succeeded)
            {
                throw new Exception("Failed to create user");
            }

            var addToRoleResult = await userManager.AddToRoleAsync(entity, UserRoles.Admin);
            if (!addToRoleResult.Succeeded)
            {
                throw new Exception($"Failed to assign role: {UserRoles.Admin} to user");
            }

            biker.User = entity;

            await dbContext.Bikers.AddAsync(biker);

            await transaction.CommitAsync();

            return true;
        }
        catch (Exception)
        {

            await transaction.RollbackAsync();
            return false;
        }
    }
}
}
