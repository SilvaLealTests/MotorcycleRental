using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using System.Text.Json.Serialization;

namespace MotorcycleRental.Application.Users.Dtos
{
    public class BikerDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string CNPJ { get; set; } = default!;

        public DateOnly DateOfBirth { get; set; }

        public string CNH { get; set; } = default!;

        public CNHTypes CNHType { get; set; }

        public string? CHNImg { get; set; }

    }
}
