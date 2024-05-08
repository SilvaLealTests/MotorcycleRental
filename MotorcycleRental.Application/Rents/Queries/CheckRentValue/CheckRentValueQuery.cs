using MediatR;

namespace MotorcycleRental.Application.Rents.Queries.CheckRentValue
{
    public class CheckRentValueQuery : IRequest<decimal>
    {
        public DateOnly PreviewDate { get; set; }
    }
}
