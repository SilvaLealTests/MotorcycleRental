using MotorcycleRental.Application.Motorcycles.Dtos;
using MotorcycleRental.Application.RentPlans.Dtos;
using MotorcycleRental.Application.Users.Dtos;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Rents.Dtos
{
    public class RentDto
    {
        public int Id { get; set; }


        
        public RentPlanDto RentPlan { get; set; } = new();

       

        public BikerDto Biker { get; set; } = new();

       

        public MotorcycleDto Motorcycle { get; set; } = new();

       

        public DateTime InitialDate { get; set; }

        public DateTime? FinalDate { get; set; }

        public DateTime PreviewDate { get; set; }
    }
}
