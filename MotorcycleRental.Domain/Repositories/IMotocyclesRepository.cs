using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using System.ComponentModel;

namespace MotorcycleRental.Infrastructure.Repositories
{
    public interface IMotocyclesRepository
    {
        Task<IEnumerable<Motorcycle>> GetAllAsync();

        Task<Motorcycle?> GetByIdAsync(int id);

        Task<int> Create(Motorcycle entity);

        Task Delete(Motorcycle entity);

        Task SaveChanges();

        Task<(IEnumerable<Motorcycle>, int)> GetAllMachingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    }
}