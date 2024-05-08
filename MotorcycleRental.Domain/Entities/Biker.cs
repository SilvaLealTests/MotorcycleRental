using MotorcycleRental.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRental.Domain.Entities
{
    public class Biker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CNPJ { get; set; } = default!;

        public DateOnly DateOfBirth { get; set; }

        public string CNH { get; set; } = default!;

        public CNHTypes CNHType { get; set; }

        public string? CHNImg { get; set; }

        public List<Rent> Rents { get; set; } = new();

        public User User { get; set; }


    }
}
