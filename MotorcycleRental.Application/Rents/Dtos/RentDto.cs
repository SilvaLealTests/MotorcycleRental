﻿using MotorcycleRental.Application.Bikers.Dtos;
using MotorcycleRental.Application.Motorcycles.Dtos;
using MotorcycleRental.Application.RentPlans.Dtos;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Rents.Dtos
{
    public class RentDto
    {
        public int Id { get; set; }


        
        public RentPlanDto RentPlan { get; set; } = new();

       

        public BikerDto Biker { get; set; } = new();

        public MotorcycleDto Motorcycle { get; set; } = new();
        
        public DateOnly InitialDate { get; set; }

        public DateTime? FinalDate { get; set; }

        public DateOnly PreviewDate { get; set; }
    }
}
