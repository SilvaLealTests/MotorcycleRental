using MediatR;
using MotorcycleRental.Application.Motorcycles.Dtos;

namespace MotorcycleRental.Application.Motorcycles.Queries.GetAllMotorcycles
{
    public class GetAllMotorcyclesQuery : IRequest<IEnumerable<MotorcycleDto>>
    {
    }
}
