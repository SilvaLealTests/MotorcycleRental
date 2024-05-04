namespace MotorcycleRental.Domain.Entities;

public class Motorcycle
{    
    public int Id { get; set; }

    public int Year { get; set; }

    public string Model { get; set; } = default!;

    public string LicensePlate { get; set; } = default!;
}
