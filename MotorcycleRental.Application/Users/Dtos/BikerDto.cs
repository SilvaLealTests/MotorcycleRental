using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Users.Dtos
{
    public class BikerDto
    {
        public string CNPJ { get; set; } = default!;

        public DateOnly DateOfBirth { get; set; }

        public string CNH { get; set; } = default!;

        public CNHTypes CNHType { get; set; }

        public string? CHNImg { get; set; }

    }
}
