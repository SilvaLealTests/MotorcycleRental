namespace MotorcycleRental.Domain.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public RentalPlan RentalPlan { get; set; } = new();

        public User Biker { get; set; } = new();

        public Motorcycle Motorcycle { get; set; } = new();

        public DateTime InitialDate { get; set; }

        public DateTime? FinalDate { get; set; }

        public DateTime PreviewDate { get; set; }


    }
}
