using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRental.Domain.Entities;

public class Motorcycle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]    
    public int Year { get; set; }

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = default!;

    [Required]
    [MaxLength(10)]
    public string LicensePlate { get; set; } = default!;
}
