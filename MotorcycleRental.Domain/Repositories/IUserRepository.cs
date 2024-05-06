using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    public interface IUserRepository
    {
          Task<IdentityResult> InsertBiker(User entity, string password);
    }
}
