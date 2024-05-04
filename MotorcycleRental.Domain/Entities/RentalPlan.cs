namespace MotorcycleRental.Domain.Entities
{
    public class RentalPlan
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;

        public int Days { get; set; }

        public decimal Cost { get; set; }
    }
}
