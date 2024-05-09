using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Domain.Repositories
{
    public interface IUsersRepository
    {
          Task<bool> InsertBiker(User entity, string password,Biker biker);

        Task<bool> InsertAdmin(User entity, string password);
    }
}
