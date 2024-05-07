using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> InsertBiker(User entity, string password);

        Task<bool> InsertAdmin(User entity, string password);
    }
}
