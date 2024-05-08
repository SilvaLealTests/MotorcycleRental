namespace MotorcycleRental.Domain.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public RentPlan RentalPlan { get; set; } = new();

        public int RetalPlaId{ get; set; }

        public Biker Biker { get; set; } = new();

        public int BikerId { get; set; }
                
        public Motorcycle Motorcycle { get; set; } = new();

        public int MotorcycleId { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime? FinalDate { get; set; }

        public DateTime PreviewDate { get; set; }


    }
}
