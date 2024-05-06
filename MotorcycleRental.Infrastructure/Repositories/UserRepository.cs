using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Infrastructure.Repositories
{
    internal class UserRepository(UserManager<User> userManager) : IUserRepository
    {
        public async Task<IdentityResult> InsertBiker(User entity,string password)
        {
            var user = await userManager.CreateAsync(entity, password);

            return user;
        }
    }
}
